using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus{
    public class HUDController : MonoBehaviour{
        private bool isDisplayedOn;

        void OnEnable(){
            RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
        }

        void OnDisable(){
            RaceEventBus.Unsubscribe(RaceEventType.START, DisplayHUD);
        }

        private void DisplayHUD(){
            isDisplayedOn = true;
        }

        void OnGUI(){
            if(isDisplayedOn){
                if(GUILayout.Button("Stop Race")){
                    isDisplayedOn = false;
                    RaceEventBus.Publish(RaceEventType.STOP);
                }
            }
        }
    }
}