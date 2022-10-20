using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _9b
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker.DoWork += ProgressBarRun_DoWork;
            backgroundWorker.ProgressChanged += ProgressBarRun_Update;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        BackgroundWorker backgroundWorker = new BackgroundWorker();

        int progress;
        bool direction = true;
        private void ProgressBarRun_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is BackgroundWorker worker)
            {
                progress = Convert.ToInt32(e.Argument);
                while (true)
                {
                    Thread.Sleep(1);
                    if (direction)
                    {
                        if (progress == 1000)
                        {
                            direction = false;
                            continue;
                        }
                        progress++;
                    }
                    else
                    {
                        if (progress == 0)
                        {
                            direction = true;
                            continue;
                        }
                        progress--;
                    }
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    backgroundWorker.ReportProgress(0, progress);
                }

            }
        }

        private void ProgressBarRun_Update(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarMain.Value = (int)e.UserState;
            progressLabel.Content = (int)e.UserState;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ButtonStop.IsEnabled = true;
            ButtonStart.IsEnabled = false;

            backgroundWorker.RunWorkerAsync(ProgressBarMain.Value);
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            ButtonStop.IsEnabled = false;
            ButtonStart.IsEnabled = true;

            backgroundWorker.CancelAsync();
        }
    }
}
