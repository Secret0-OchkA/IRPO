using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.ElevatorLib
{
    internal class ElevatorMechanism
    {
        public readonly int floors;
        public IElevatorMoveState moveState;
        public IElevatorDoorState doorState;
        public MoveDirection curDirection = MoveDirection.Null;

        int curFloor = 1;
        public int CurFloor { get => curFloor; set { curFloor = value; curFloorChange(curFloor); } }

        public delegate void DoorStateHandler(string satatus);
        public DoorStateHandler doorStateChange;
        public delegate void CurFloorHandler(int floor);
        public CurFloorHandler curFloorChange;

        public ElevatorMechanism(int floors, IElevatorMoveState moveState, IElevatorDoorState doorState)
        {
            this.floors = floors;
            this.moveState = moveState;
            this.doorState = doorState;
        }

        public void Open() => doorState.Open(this);
        public void Close() => doorState.Close(this);

        public void Stop() => moveState.Stop(this);
        void Up() => moveState.Up(this);
        void Down() => moveState.Down(this);

        public void MoveTo(int floor)
        {
            if (floors < floor || floor < 1)
            {
                Stop();
                Open();
                return;
            }

            if (floor < CurFloor) //if call Down
                while (floor != CurFloor)
                {
                    Down();
                }
            else if (floor > CurFloor) //if call Up
                while (floor != CurFloor)
                {
                    Up();
                }

            Stop();
            Open();
        }
    }

    enum MoveDirection
    {
        Null,
        Up,
        Down,
    }
}
