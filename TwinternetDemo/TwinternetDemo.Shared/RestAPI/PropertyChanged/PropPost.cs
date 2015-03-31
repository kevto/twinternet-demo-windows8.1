using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwinternetDemo.RestAPI.PropertyChanged
{
    public class PropPost : INotifyPropertyChanged 
    {
        private string _author;
        private string _title;
        private string _dateAndTime;

        public string Author
        {
            get
            {
                return this._author;
            }

            set
            {
                this._author = value;
                RaisePropertyChanged("Author");
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                this._title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string DateAndTime
        {
            get
            {
                return this._dateAndTime;
            }

            set
            {
                this._dateAndTime = value;
                RaisePropertyChanged("DateAndTime");
            }
        }

        public PropPost(string author, string title, string dateandtime = "")
        {
            this.Author = author;
            this.Title = title;
            this.DateAndTime = dateandtime;
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
