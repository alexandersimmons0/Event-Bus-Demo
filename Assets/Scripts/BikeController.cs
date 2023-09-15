using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus{
    public class BikeController : MonoBehaviour{
        private string status;

        void OnEnable(){
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        }

        void OnDisable(){
            RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);       
        }

        private void StartBike(){
            status = "Started";
        }

        private void StopBike(){
            status = "Stopped";
        }

        void OnGUI(){
            GUI.color = Color.green;
            GUI.Label(new Rect(10,60,200,20), "Bike Status = " + status);
        }
    }
}
