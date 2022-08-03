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
using System.Windows.Threading;

namespace FamilyTree_ECE1895
{
    public struct Vertex
    {
        public Vertex(string name, int age, int id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        
        public string Name;
        public int Age, Id;

        public static bool operator ==(Vertex c1, Vertex c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Vertex c1, Vertex c2)
        {
            return !c1.Equals(c2);
        }
    }

    public struct Edge
    {
        public Edge(Vertex name1, Vertex name2, int level)
        {
            Name1 = name1;
            Name2 = name2;
            Level = level;
        }

        public Vertex Name1, Name2;
        public int Level;

        public static bool operator ==(Edge c1, Edge c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Edge c1, Edge c2)
        {
            return !c1.Equals(c2);
        }

        public static bool operator |(Edge c1, Edge c2)
        {
            return (c1.Name1 == c2.Name2) || (c1.Name2 == c2.Name1);
        }
    }

    public partial class MainWindow : Window
    {
        Brush CustomBrush;
        Random r = new Random();

        DispatcherTimer UITimer;

        public List<Vertex> NameList = new List<Vertex>();
        public List<Edge> EdgeList = new List<Edge>();

        public int Id = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitTimer();
        }

        public void addItem(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRec = (Rectangle)e.OriginalSource;

                int i = 0;

                while ((NameList[i].Name + "\n" + NameList[i].Age + "\nID: " + NameList[i].Id) != activeRec.ToolTip.ToString())
                {
                    i++;
                }

                ViewItemWindow newMember = new ViewItemWindow(activeRec,i);
                newMember.Topmost = true;
                newMember.Show();
                newMember.Activate();
            }

            else
            {
                // generate a random brush color:
                CustomBrush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                (byte)r.Next(1, 255), (byte)r.Next(1, 233)));


                Rectangle newRec = new Rectangle
                {
                    Width = 25,
                    Height = 25,
                    StrokeThickness = 3,
                    Fill = CustomBrush,
                    Stroke = Brushes.Black
                };

                Canvas.SetLeft(newRec, Mouse.GetPosition(Canvas).X); // set the left position of rectangle to mouse X
                Canvas.SetTop(newRec, Mouse.GetPosition(Canvas).Y); // set the top position of rectangle to mouse Y

                AddItemWindow newMember = new AddItemWindow(newRec);
                newMember.Topmost = true;
                newMember.Show();
                newMember.Activate();
            }
        }

        public void InitTimer()
        {
            UITimer = new DispatcherTimer();

            UITimer.Tick += new EventHandler(UpdateUI);

            UITimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            UITimer.Start();
        }

        public void UpdateUI(object sender, EventArgs e)
        {
            FamilySize.Text = "Family Size: " + NameList.Count;
            EdgeCount.Text = "Edge Count: " + EdgeList.Count;
        }
    }
}
