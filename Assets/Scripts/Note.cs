using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    Lane lane;
    void Start()
    {
        lane = GetComponentInParent<Lane>();
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        
        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.forward * SongManager.Instance.noteSpawnY, Vector3.forward * SongManager.Instance.noteDespawnY, t); 
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void Hit()
    {
        ScoreManager.Hit();
    }
    private void Miss()
    {
        ScoreManager.Miss();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print(other.gameObject.tag);
            Hit();
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Despawn"))
        {
            print(other.gameObject.tag);
            Miss();
            Destroy(this.gameObject);
        }
        //print(other.gameObject.tag);

        //if (other.gameObject.CompareTag("Player"))
        //{
        //    if (lane.inputIndex < lane.timeStamps.Count)
        //    {
        //        double timeStamp = lane.timeStamps[lane.inputIndex];
        //        double marginOfError = SongManager.Instance.marginOfError;
        //        double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

        //        if (other.gameObject.CompareTag("Player"))
        //        {
        //                Hit();
        //                print($"Hit on {lane.inputIndex} note");
        //                //Destroy(notes[inputIndex].gameObject);
        //                Destroy(this.gameObject);
        //                lane.inputIndex++;
        //            if (Math.Abs(audioTime - timeStamp) < marginOfError)
        //            {
        //            }
        //            else
        //            {
        //                print($"Hit inaccurate on {lane.inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
        //            }
        //        }
        //        if (timeStamp + marginOfError <= audioTime)
        //        {
        //            Miss();
        //            print($"Missed {lane.inputIndex} note");
        //            lane.inputIndex++;
        //        }
        //    }
        //}
    }
}
