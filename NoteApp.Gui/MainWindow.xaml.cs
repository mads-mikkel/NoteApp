using NoteApp.DataAccess;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace NoteApp.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            Notes = new();
            DataContext = this;
            FillListBox();
        }

        private void FillListBox()
        {
            // 1. Lav et nyt objekt af repository:
            NotesRepository repository = new();

            // 2. Hent alle notes fra repository:
            List<Note> notes = repository.GetAllNotes();

            // 3. Overfør alle notes til ObservableCollection
            foreach(Note note in notes)
            {
                Notes.Add(note);
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Note selectedNote = listBoxNotes.SelectedItem as Note;
            if(selectedNote != null)
            {
                textBoxTitle.Text = selectedNote.Title;
                textBoxText.Text = selectedNote.Text;
            }
        }
    }
}