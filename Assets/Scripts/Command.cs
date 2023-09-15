using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command{
    public abstract void Execute();
}

namespace Chapter.Commands{
    public class ToggleTurbo : Command{
        private BikeControl _controller;

        public ToggleTurbo(BikeControl controller){
            _controller = controller;
        }

        public override void Execute(){
            _controller.ToggleTurbo();
        }
    }

    public class TurnLeft : Command{
        private BikeControl _controller;

        public TurnLeft(BikeControl controller){
            _controller = controller;
        }

        public override void Execute(){
            _controller.Turn(BikeControl.Direction.Left);
        }
    }

    public class TurnRight : Command{
        private BikeControl _controller;

        public TurnRight(BikeControl controller){
            _controller = controller;
        }

        public override void Execute(){
            _controller.Turn(BikeControl.Direction.Right);
        }
    }
}