using System.ComponentModel;
using System.Windows;

namespace Yokogawa_Simple_Calculater
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double value1,result;
        private string opp;

        public MainWindow()
        {
            InitializeComponent();

            // Set the DataContext to the window itself
            this.DataContext = this;

            // Initialize the result
            m_Input = 0; // Use the property to trigger OnPropertyChanged
        }

        private void Equal()
        { 
            Log = Log + string.Format("{0} =",  Input);
            switch (opp)
            {
                case "+":
                    Input = value1 + m_Input;
                    break;
                case "-":
                    Input = value1 - m_Input;
                    break;
                case "*":
                    Input = value1 * m_Input;
                    break;
                case "/":
                    Input = value1 / m_Input;
                    break;
                case "^":
                    Input =Math.Pow( value1 , m_Input);
                    break;
            }

            Log = Log + string.Format("{0}\n", Input);
            value1 = Input;
        }
        private void ButtonClick()
        {
            if (value1 == 0)
            {
                value1 = m_Input;
            }
            else
            {
                Equal();
            }

            Log = Log + string.Format("{0}{1}", value1,opp);
            Input = 0;
        }

        #region Binding
        // Event handler for the plus button click
        public void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            Equal();
            value1 = 0;
        }
        public void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            opp = "+";
            ButtonClick();
        }
        public void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            opp = "-";
            ButtonClick();
        }
        public void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            opp = "*";
            ButtonClick();
        }
        public void DevideButton_Click(object sender, RoutedEventArgs e)
        {
            opp = "/";
            ButtonClick();
        }
        public void ExponentiationButton_Click(object sender, RoutedEventArgs e)
        {
            opp = "^";
            ButtonClick();
        }

        public void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {

            Log = string.Format("√{0} = ", Input);
            Input = Math.Sqrt(Input);
            Log = Log + string.Format("{0}\n", Input);
            value1 = 0;
        }
        public void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            value1 = 0;
            Input = 0;
            Log = "";
        }

        public void ClearInputButton_Click(object sender, RoutedEventArgs e)
        {
            Input = 0;
        }
        #endregion

#region property
        // Backing field for the Result property
        private string m_Log;

        // Result property with change notification
        public string Log
        {
            get { return m_Log; }
            set
            {
                if (m_Log != value)
                {
                    m_Log = value;
                    OnPropertyChanged(nameof(Log)); // Notify the UI of the change
                }
            }
        }
        private double m_Input;

        // Result property with change notification
        public double Input
        {
            get { return m_Input; }
            set
            {
                if (m_Input != value)
                {
                    m_Input = value;
                    OnPropertyChanged(nameof(Input)); // Notify the UI of the change
                }
            }
        }
        #endregion

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}