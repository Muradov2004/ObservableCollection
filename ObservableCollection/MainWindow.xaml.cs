using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace ObservableCollection
{
    class Person
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> person;
        public MainWindow()
        {
            InitializeComponent();
            person = new ObservableCollection<Person>()
            {
                new Person(){Name="Ali",Surname="Muradov"},
            };
            lstNames.ItemsSource = person;
        }
        private void btnNames_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != string.Empty && txtSurname.Text != string.Empty)
                person.Add(new Person() { Name = txtName.Text, Surname = txtSurname.Text });
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
        }

        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoWindow infoWindow = new();
            infoWindow.NameBlock.Text = "Name : " + person[lstNames.SelectedIndex].Name;
            infoWindow.SurnameBlock.Text = "Surname : " + person[lstNames.SelectedIndex].Surname;
            infoWindow.Show();
        }
    }
}
