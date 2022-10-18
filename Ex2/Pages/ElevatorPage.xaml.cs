using Ex2.ElevatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ElevatorPage.xaml
    /// </summary>
    public partial class ElevatorPage : Page
    {
        public ElevatorPage(int floors)
        {
            InitializeComponent();

            IElevatorMoveState moveState = new ElevatorStandeState();
            IElevatorDoorState doorState = new ElevatorCloseState();
            ElevatorMechanism mechanism = new ElevatorMechanism(floors, moveState, doorState);
            elevator = new Elevator(mechanism);

            elevator.CurFloorHandler += UpdateCurFloor;
            elevator.DoorStateHandler += UpdateDoorState;
        }

        Elevator elevator { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                string content = button.Content.ToString();

                switch(content)
                {
                    case "1": case "2": case "3":
                    case "4": case "5": case "6":
                    case "7": case "8": case "9":
                    case "0":
                        TextBlock_FloorNumber.Text += content;
                        break;

                    case "O":
                        int floor = 1;
                        if (TextBlock_FloorNumber.Text.Length > 0)
                        {
                            int.TryParse(TextBlock_FloorNumber.Text, out floor);
                            CallElevator(floor);
                            TextBlock_FloorNumber.Text = "";
                        }
                        break;
                    case "X":
                        if (TextBlock_FloorNumber.Text.Length > 0)
                            TextBlock_FloorNumber.Text = TextBlock_FloorNumber.Text.Remove(TextBlock_FloorNumber.Text.Length - 1);
                        break;
                }
            }
        }

        private void CallElevator(int floor)
        {
            elevator.Close();
            elevator.Call(floor);
        }

        private void UpdateCurFloor(int floor)
        {
            TextBlock_CurrentFloor.Text = floor.ToString();
        }
        private void UpdateDoorState(string state)
        {
            TextBlock_DoorStatus.Text = state;
        }
    }
}
