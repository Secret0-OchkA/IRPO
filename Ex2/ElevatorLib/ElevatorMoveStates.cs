using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.ElevatorLib
{
    internal interface IElevatorMoveState
    {
        void Up(ElevatorMechanism elevator);
        void Down(ElevatorMechanism elevator);
        void Stop(ElevatorMechanism elevator);
    }

    #region MoveStates
    class ElevatorMoveUpState : IElevatorMoveState
    {
        public void Down(ElevatorMechanism elevator)
        {
            if (elevator.CurFloor > 1)
            {
                elevator.curDirection = MoveDirection.Down;
                elevator.CurFloor--;
                elevator.moveState = new ElevatorMoveDownState();
            }
        }

        public void Stop(ElevatorMechanism elevator)
        {
            elevator.moveState = new ElevatorStandeState();
        }

        public void Up(ElevatorMechanism elevator)
        {
            if (elevator.CurFloor < elevator.floors)
            {
                elevator.curDirection = MoveDirection.Up;
                elevator.CurFloor++;
            }
        }
    }

    class ElevatorMoveDownState : IElevatorMoveState
    {
        public void Down(ElevatorMechanism elevator)
        {
            if (elevator.CurFloor > 1)
            {
                elevator.curDirection = MoveDirection.Down;
                elevator.CurFloor--;
            }
        }

        public void Stop(ElevatorMechanism elevator)
        {
            elevator.moveState = new ElevatorStandeState();
        }

        public void Up(ElevatorMechanism elevator)
        {
            if (elevator.CurFloor < elevator.floors)
            {
                elevator.curDirection = MoveDirection.Up;
                elevator.CurFloor++;
                elevator.moveState = new ElevatorMoveUpState();
            }
        }
    }

    class ElevatorStandeState : IElevatorMoveState
    {
        public void Down(ElevatorMechanism elevator)
        {
            if (elevator.CurFloor > 1 && elevator.doorState is ElevatorCloseState)
            {
                elevator.curDirection = MoveDirection.Down;
                elevator.CurFloor--;
                elevator.moveState = new ElevatorMoveDownState();
            }
        }

        public void Stop(ElevatorMechanism elevator) { }

        public void Up(ElevatorMechanism elevator)
        {
            if (elevator.CurFloor < elevator.floors && elevator.doorState is ElevatorCloseState)
            {
                elevator.curDirection = MoveDirection.Up;
                elevator.CurFloor++;
                elevator.moveState = new ElevatorMoveUpState();
            }
        }
    }
    #endregion
}
