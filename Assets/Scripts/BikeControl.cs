using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : MonoBehaviour{
    public enum Direction{
        Left = -1,
        Right = 1
    }

    private bool isTurboOn;
    private float distance = 0.1f;

    public void ToggleTurbo(){
        isTurboOn = !isTurboOn;
    }

    public void Turn(Direction direction){
        if(direction == Direction.Left){
            transform.Translate(Vector3.left * distance);
        }
        if(direction == Direction.Right){
            transform.Translate(Vector3.right * distance);
        }
    }

    public void ResetPosition(){
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
