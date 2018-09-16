using PostSharp.Patterns.Collections;
using PostSharp.Patterns.Model;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random Random = new Random();
        Model Model => DataContext as Model;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var i = Random.Next(Model.Tests.Count);
            Model.Test = Model.Tests[i];
        }
    }

    [Aggregatable]
    [NotifyPropertyChanged]
    [ContentProperty("Tests")]
    public class Model
    {
        [Child] public AdvisableCollection<Test> Tests { get; } = new AdvisableCollection<Test>();
        [Child] public Test Test { get; set; }
    }

    [Aggregatable]
    [NotifyPropertyChanged]
    public class Test
    {
        public string Name { get; set; }
        [Parent] public Model Model { get; private set; }
    }
}
