using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwinternetDemo
{
    public class DemoProp : INotifyPropertyChanged 
    {
        private string _demo;
        private int _count = 0;

        public string Demo
        {
            get
            {
                return this._demo;
            }

            set
            {
                _count++;
                this._demo = "Times changed: " + value;
                RaisePropertyChanged("Demo");
            }
        }

        public DemoProp()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        } 
    }
}
