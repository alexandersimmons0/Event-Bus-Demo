using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus{
    public class CountdownTimer : MonoBehaviour{
        private float currentTime;
        private float duration = 3.0f;

        void OnEnable(){
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
        }

        void OnDisable(){
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
        }

        private void StartTimer(){
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown(){
            currentTime = duration;
            while(currentTime > 0){
                yield return new WaitForSeconds(1f);
                currentTime--;
            }
            RaceEventBus.Publish(RaceEventType.START);
        }

        void OnGUI(){
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 100, 20), "Countdown: " + currentTime);
        }
    }
}
