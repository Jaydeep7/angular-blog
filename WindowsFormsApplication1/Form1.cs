using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async Task TestAsync()
        {
            Task<int>[] tasks = new Task<int>[4];
            tasks[0] = task1();
            tasks[1] = task2();
            tasks[2] = task3();
            tasks[3] = task4();

            Debug.WriteLine("All task started....");

            await Task.WhenAll(tasks);

            Debug.WriteLine("All task completed!");

            Debug.WriteLine("Task1 result : " + tasks[0].Result.ToString());
            Debug.WriteLine("Task1 result : " + tasks[1].Result.ToString());
            Debug.WriteLine("Task1 result : " + tasks[2].Result.ToString());
            Debug.WriteLine("Task1 result : " + tasks[3].Result.ToString());


        }

        public async Task<int> task1()
        {
            await Task.Delay(1000);
            return 1;
        }

        public async Task<int> task2()
        {
            await Task.Delay(2000);
            return 2;
        }

        public async Task<int> task3()
        {
            await Task.Delay(3000);
            return 3;
        }

        public async Task<int> task4()
        {
            await Task.Delay(4000);
            return 4;
        }
    }
}
