using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using sub_download.Annotations;

namespace sub_download
{
    /// <summary> класс работы с ListBox </summary>
    public class ListBoxWorks
    {
        /// <summary> сам ListBox </summary>
        public ListBox Listbox;
        /// <summary> список отвечающий записям в ListBox </summary>
        public List<DataBaseRecord> ListOfItems;
        /// <summary> Имя ListBox </summary>
        public string ParentName;
        /// <summary> Номер выбранного ListBoxItem </summary>
        public int SelectedIndex;
        /// <summary> Выделенный в данный момент элемент </summary>
        public DataBaseRecord SelectedItem;

        /// <summary> Конструктор. Связывает указанный ListBox с создаваемым экземпляром </summary>
        public ListBoxWorks(ListBox listbox)
        {
            //объект для которого пишется класс связи
            Listbox = listbox;
            // список элементов в селекторе
            ListOfItems = new List<DataBaseRecord>();

            //узнаём имя, если оно существует
            ParentName = listbox.Name;
            
            //Узнаём номер выбранного в данный момент ListBoxItem
            SelectedIndex = listbox.SelectedIndex;

            //Записываем выбранный в данный момент ListBoxItem
            if (SelectedIndex != -1) SelectedItem = ListOfItems[SelectedIndex];

            //считываем новое выделение
            listbox.SelectionChanged += SelectionEvent;
        }
        

        /// <summary> Обновляет содержимое селектора </summary>
        public void UpdateListbox()
        {
            //очищаем Listbox
            Listbox.Items.Clear();
            
            var templist = new List<string>();

            //конвертируем ListOfItems типа DataBaseRecord в список templist типа String
            for (var i = 0; i < ListOfItems.Count; i++)
            {
                templist.Add(ListOfItems[i].Name);
            }

            //Заполняем Listbox элементами
            foreach (var selString in templist)
            {
                var tempItem = new ListBoxItem {Content = selString};
                Listbox.Items.Add(tempItem);
            }
        }
        
        /// <summary> обработчик выбора в ListBox. Записывает текущий выбор в SelectedItem </summary>
        public void SelectionEvent(object sender, SelectionChangedEventArgs args)
        {
            
            SelectedIndex = Listbox.SelectedIndex;
            if (SelectedIndex != -1) SelectedItem = ListOfItems[SelectedIndex];

           
        }
    }
}
