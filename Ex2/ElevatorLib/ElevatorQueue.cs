using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace Ex2.ElevatorLib
{
    internal class ElevatorQueue
    {
        List<Func<Task>> calls = new List<Func<Task>>();
        int curTarget;
        bool IsWorking = false;

        public async Task Add(int floor, ElevatorMechanism mechanism)
        {
            if (floor < 0 || mechanism.floors < floor) return;

            Func<Task> moveTo = new Func<Task>(async () =>
            {
                IsWorking = true;
                mechanism.MoveTo(floor);
                Dequeue();
                await calls[0]?.Invoke();
            });

            if (mechanism.CurFloor < floor && curTarget > floor && mechanism.curDirection == MoveDirection.Down)
            {
                curTarget = floor;
                calls.Insert(0, moveTo);
            }
            else if (mechanism.CurFloor > floor && curTarget < floor && mechanism.curDirection == MoveDirection.Up)
            {
                curTarget = floor;
                calls.Insert(0, moveTo);
            }
            else
                calls.Add(moveTo);

            if (!IsWorking)
                await calls[0]?.Invoke();
        }

        void Dequeue()
        {
            if (calls.Count > 0)
                calls.RemoveAt(0);
            else
                IsWorking = false;
        }
    }
}
