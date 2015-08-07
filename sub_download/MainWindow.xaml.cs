using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace sub_download
{
    public partial class MainWindow
    {
        private static MainWindow _wm;
        public ListBoxWorks archiveSelector;
        public ListBoxWorks ForumSelector;

        /// <summary> конструктор  </summary>
        public MainWindow()
        {
            InitializeComponent();
            //создание статической ссылки на объект MainWindow 
            _wm = this;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            archiveSelector = new ListBoxWorks(ArchiveRecordsListBox);
            ForumSelector = new ListBoxWorks(ForumRecordsListBox);
            var templist = new List<DataBaseRecord>();

            for (var i = 0; i < 4; i++)
            {
                templist.Add(new DataBaseRecord {Name = i.ToString()});
            }
            
            archiveSelector.ListOfItems.AddRange(templist);
            archiveSelector.UpdateListbox();



            MessageBox.Show(archiveSelector.ParentName + "\n" + 
                            archiveSelector.SelectedIndex + "\n" +
                            archiveSelector.ListOfItems.Count);


        }




    }
}

    
