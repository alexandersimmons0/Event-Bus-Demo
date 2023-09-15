using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Chapter.Commands{
    public class Invoker : MonoBehaviour{
        private bool isRecording;
        private bool isReplaying;
        private float replayTime;
        private float recordingTime;
        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command){
            command.Execute();
            if(isRecording){
                _recordedCommands.Add(recordingTime, command);
            }
        }

        public void Record(){
            recordingTime = 0.0f;
            isRecording = true;
        }

        public void Replay(){
            replayTime = 0.0f;
            isReplaying = true;
            _recordedCommands.Reverse();
        }

        void Update(){
            if(isRecording){
                recordingTime += Time.deltaTime;
            }
            if(isReplaying){
                replayTime += Time.deltaTime;
                if(_recordedCommands.Any()){
                    Debug.Log(replayTime);
                    if(Mathf.Approximately(replayTime, _recordedCommands.Keys[0])){
                        Debug.Log("Replay Time: " + replayTime);
                        Debug.Log("Replay Command: " + _recordedCommands.Values[0]);
                        _recordedCommands.Values[0].Execute();
                        _recordedCommands.RemoveAt(0);
                    }
                }else{
                    Debug.Log("replay over");
                    isReplaying = false;
                }
            }
        }
    }
}
