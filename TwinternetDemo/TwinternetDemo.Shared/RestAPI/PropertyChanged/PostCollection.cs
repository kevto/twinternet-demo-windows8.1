using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace TwinternetDemo.RestAPI.PropertyChanged
{
    public class PostCollection : INotifyPropertyChanged
    {
        private ObservableCollection<PropPost> _items { get; set; }

        public ObservableCollection<PropPost> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        } 
    }
}
