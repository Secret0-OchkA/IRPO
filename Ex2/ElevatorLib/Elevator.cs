using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Ex2.ElevatorLib.ElevatorMechanism;

namespace Ex2.ElevatorLib
{
    class Elevator
    {
        ElevatorMechanism mechanism;

        public Elevator(ElevatorMechanism mechanism)
        {
            this.mechanism = mechanism;
        }

        public DoorStateHandler DoorStateHandler { get => mechanism.doorStateChange; set => mechanism.doorStateChange = value; }
        public CurFloorHandler CurFloorHandler { get => mechanism.curFloorChange; set => mechanism.curFloorChange = value; }

        public void Call(int floor) => mechanism.MoveTo(floor);  

        public int GetCurrentFloor() => mechanism.CurFloor;

        public void Close() => mechanism.Close();

        public void Open() => mechanism.Open();

        public void Stop() => mechanism.Stop();
    }
}
