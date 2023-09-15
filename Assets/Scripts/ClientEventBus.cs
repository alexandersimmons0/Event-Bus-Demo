using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus{
    public class ClientEventBus : MonoBehaviour{
        private bool isButtonEnabled;

        void Start(){
            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();
            isButtonEnabled = true;
        }

        void OnEnable(){
            RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
        }

        void OnDisable(){
            RaceEventBus.Unsubscribe(RaceEventType.STOP, Restart);
        }

        private void Restart(){
            isButtonEnabled = true;
        }

        void OnGUI(){
            if(isButtonEnabled){
                if(GUILayout.Button("Start Countdown")){
                    isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.COUNTDOWN);
                }
            }
        }
    }
}