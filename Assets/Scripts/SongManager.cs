using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{
    [Header("DEBUG")]
    [SerializeField] bool isDebug = false;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject despawnPoint;
    [SerializeField] GameObject playerPoint;

    public static SongManager Instance;
    [Header("PROPERTY")]
    [Space(20f)]
    public AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;
    

    public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;

    [SerializeField] float actualDespawn = -13f;

    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    

    //LaneManager laneManager;

    public static MidiFile midiFile;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        if (isDebug)
        {
            if (spawnPoint != null)
            {
                spawnPoint.SetActive(true);
                spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, noteSpawnY);
            }

            if (despawnPoint != null)
            {
                despawnPoint.SetActive(true);
                despawnPoint.transform.position = new Vector3(despawnPoint.transform.position.x, despawnPoint.transform.position.y, actualDespawn);
            }

            if (playerPoint != null)
            {
                playerPoint.SetActive(true);
                playerPoint.transform.position = new Vector3(playerPoint.transform.position.x, playerPoint.transform.position.y, 1);
            }
        }
        else
        {
            spawnPoint?.SetActive(false);
            despawnPoint?.SetActive(false);
            playerPoint?.SetActive(false);
        }

        //laneManager = GetComponent<LaneManager>();
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }

    private IEnumerator ReadFromWebsite()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                byte[] results = www.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        //laneManager.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
        audioSource.Play();
    }
    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }
}
