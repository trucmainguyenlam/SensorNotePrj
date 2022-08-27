using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiParser;

namespace SensorNotePrj
{
    public class MidiController : MonoBehaviour
    {
        [SerializeField] string path;

        [SerializeField] GameObject prefab;

        [SerializeField] int[] lane;

        int preTime = 0;

        private void Start()
        {
            print($"Parsing: {path}\n");

            var midiFile = new MidiFile(path);

            print($"Format: {midiFile.Format}");
            print($"TicksPerQuarterNote: {midiFile.TicksPerQuarterNote}");
            print($"TracksCount: {midiFile.TracksCount}");
            
            var timeRate = 500 / midiFile.TicksPerQuarterNote;

            foreach (var track in midiFile.Tracks)
            {
                print($"\nTrack: {track.Index}\n");

                foreach (var midiEvent in track.MidiEvents)
                {
                    //const string Format = "{0} Channel {1} Time {2} Args {3} {4} Note {}";
                    //if (midiEvent.MidiEventType == MidiEventType.MetaEvent)
                    //{
                    //    //print(
                    //    //    Format,
                    //    //    midiEvent.MetaEventType,
                    //    //    "-",
                    //    //    midiEvent.Time,
                    //    //    midiEvent.Arg2,
                    //    //    midiEvent.Arg3);
                    //    print($"{midiEvent.MetaEventType} Channel " +
                    //        $"- Time {midiEvent.Time} " +
                    //        $"Args {midiEvent.Arg2} {midiEvent.Arg3} " +
                    //        $"Note {midiEvent.Note}");
                    //}
                    //else
                    //{
                    //    //Console.WriteLine(
                    //    //    Format,
                    //    //    midiEvent.MidiEventType,
                    //    //    midiEvent.Channel,
                    //    //    midiEvent.Time,
                    //    //    midiEvent.Arg2,
                    //    //    midiEvent.Arg3);
                    //    print($"{midiEvent.MidiEventType} " +
                    //        $"Channel {midiEvent.Channel} " +
                    //        $"Time {midiEvent.Time} " +
                    //        $"Args {midiEvent.Arg2} {midiEvent.Arg3} " +
                    //        $"Note {midiEvent.Note}");
                    //}

                    //if (midiEvent.MidiEventType == MidiEventType.NoteOn)
                    //{
                    //    var time = midiEvent.Time;

                    //    var t = time * timeRate;

                        

                    //    var channel = midiEvent.Channel;
                    //    var note = midiEvent.Note;
                    //    var velocity = midiEvent.Velocity;
                    //    print($"NOTEON Channel: {channel} " +
                    //        $"Time: {time} " +
                    //        $"Note: {note} " +
                    //        $"Velo: {velocity} ");
                    //    Instantiate(prefab, this.transform.position + new Vector3(0, 1, time), Quaternion.identity);
                    //}

                    //if (midiEvent.MidiEventType == MidiEventType.NoteOff)
                    //{
                    //    var time = midiEvent.Time;
                    //    var channel = midiEvent.Channel;
                    //    var note = midiEvent.Note;
                    //    var velocity = midiEvent.Velocity;
                    //    var t = time * timeRate;
                    //    print($"NOTEOFF Channel: {channel} " +
                    //        $"Time: {time} " +
                    //        $"Note: {note} " +
                    //        $"Velo: {velocity} ");
                    //    Instantiate(prefab, this.transform.position + new Vector3(0, 1, time), Quaternion.identity);
                    //}


                    var time = midiEvent.Time;

                    //preTime = midiEvent.Time;

                    //if (preTime <= time)
                    //{
                    //    preTime 
                    //}

                    //var t = time * timeRate;

                    //var dis = preTime < time ? time - preTime : preTime = time;

                    var channel = midiEvent.Channel;
                    var note = midiEvent.Note;
                    var velocity = midiEvent.Velocity;
                    print($"NOTEON Channel: {channel} " +
                        $"Time: {time} " +
                        $"Note: {note} " +
                        $"Velo: {velocity} ");
                    int rand = Random.Range(0, 5);

                    //Instantiate(prefab, this.transform.position + new Vector3(lane[rand], 1, dis), Quaternion.identity);

                }
            }
        }
    }

}
