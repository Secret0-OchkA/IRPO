using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace _7b
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Point mousePos;
        Point mouseDelta;
        UIElement selectElement = null;

        Action action = Action.Null;
        enum Action
        {
            Null, Rotate, Scale, Translate
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            mouseDelta.X = e.GetPosition(this).X - mousePos.X;
            mouseDelta.Y = e.GetPosition(this).Y - mousePos.Y;
            mousePos = Mouse.GetPosition(this);

            if (selectElement?.RenderTransform is TransformGroup group && e.LeftButton == MouseButtonState.Pressed)
            {
                switch (action)
                {
                    case Action.Rotate:
                        if (group.Children[0] is RotateTransform rotateTrans)
                        {
                            rotateTrans.CenterX = selectElement.RenderSize.Width / 2;
                            rotateTrans.CenterY = selectElement.RenderSize.Height / 2;
                            Rotate(rotateTrans);
                        }
                        break;
                    case Action.Scale:
                        if (group.Children[1] is ScaleTransform scaleTrans)
                        {
                            scaleTrans.CenterX = selectElement.RenderSize.Width / 2;
                            scaleTrans.CenterY = selectElement.RenderSize.Height / 2;
                            Scale(scaleTrans);
                        }
                        break;
                    case Action.Translate:
                        if (group.Children[2] is TranslateTransform translateTrans) Move(translateTrans);
                        break;
                }
            }

            MouseCords.Text = mousePos.ToString();
        }

        private void Scale(ScaleTransform rotateTrans)
        {
            rotateTrans.ScaleX += mouseDelta.X / 100;
            rotateTrans.ScaleY += mouseDelta.Y / 100;
        }

        private void Rotate(RotateTransform scaleTrans)
        {
            scaleTrans.Angle += mouseDelta.X;
            scaleTrans.Angle += mouseDelta.Y;
        }

        private void Move(TranslateTransform translateTrans)
        {
            translateTrans.X += mouseDelta.X;
            translateTrans.Y += mouseDelta.Y;
        }

        private void UIElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is UIElement element)
            {
                selectElement = element;
            }
        }
        private void UIElement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            selectElement = null;
        }

        private void btnRotate_Click(object sender, RoutedEventArgs e)
            => action = Action.Rotate;
        private void btnScale_Click(object sender, RoutedEventArgs e)
            => action = Action.Scale;
        private void btnTranslate_Click(object sender, RoutedEventArgs e)
            => action = Action.Translate;
    }
}
