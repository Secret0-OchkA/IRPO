using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.ElevatorLib
{
    internal interface IElevatorDoorState
    {
        void Open(ElevatorMechanism elevator);
        void Close(ElevatorMechanism elevator);
    }

    #region DoorState
    class ElevatorOpenState : IElevatorDoorState
    {
        public void Close(ElevatorMechanism elevator)
        {
            elevator.doorStateChange?.Invoke("close");
            elevator.doorState = new ElevatorCloseState();
        }

        public void Open(ElevatorMechanism elevator) { }
    }

    class ElevatorCloseState : IElevatorDoorState
    {
        public void Close(ElevatorMechanism elevator) { }

        public void Open(ElevatorMechanism elevator)
        {
            if (elevator.moveState is ElevatorStandeState)
            {
                elevator.doorStateChange?.Invoke("open");
                elevator.doorState = new ElevatorOpenState();
            }
        }
    }
    #endregion
}
