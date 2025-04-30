using ExamShvets.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace ExamShvets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ExamShvetsContext _context = new();
        public MainWindow()
        {
            InitializeComponent();
            

        }

        

        
    }
}