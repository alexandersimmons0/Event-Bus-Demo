using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Commands{
    public class InputHandler : MonoBehaviour{
        private Invoker _invoker;
        private bool isReplaying;
        private bool isRecording;
        private BikeControl bikeControl;
        private Command buttonA, buttonW, buttonD;

        void Start(){
            _invoker = gameObject.AddComponent<Invoker>();
            bikeControl = gameObject.AddComponent<BikeControl>();

            buttonA = new TurnLeft(bikeControl);
            buttonD = new TurnRight(bikeControl);
            buttonW = new ToggleTurbo(bikeControl);
        }

        void Update(){
            if(!isReplaying && isRecording){
                if(Input.GetKey(KeyCode.A)){
                    _invoker.ExecuteCommand(buttonA);
                }
            }
            if(!isReplaying && isRecording){
                if(Input.GetKey(KeyCode.D)){
                    _invoker.ExecuteCommand(buttonD);
                }
            }
            if(!isReplaying && isRecording){
                if(Input.GetKey(KeyCode.W)){
                    _invoker.ExecuteCommand(buttonW);
                }
            }
        }

        void OnGUI(){
            if(GUILayout.Button("Start Recording")){
                bikeControl.ResetPosition();
                isReplaying = false;
                isRecording = true;
                _invoker.Record();
            }
            if(GUILayout.Button("Stop Recording")){
                bikeControl.ResetPosition();
                isRecording = false;
            }
            if(!isRecording){
                if(GUILayout.Button("Start Replay")){
                    bikeControl.ResetPosition();
                    isRecording = false;
                    isReplaying = true;
                    Debug.Log("Replaying");
                    _invoker.Replay();
                }
            }
        }
    }
}
