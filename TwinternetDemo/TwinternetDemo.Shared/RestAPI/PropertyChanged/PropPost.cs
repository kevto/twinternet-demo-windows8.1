using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TwinternetDemo.RestAPI.PropertyChanged
{
    public class PropPost : INotifyPropertyChanged 
    {
        // Private binding properties
        private string _author;
        private string _title;
        private string _date;
        private string _modifiedDate;


        // Public accessor of Author property and raises a propertychanged notification.
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


        // Public accessor of Title property and raises a propertychanged notification.
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


        // Public accessor of Date property and raises a propertychanged notification.
        public string Date
        {
            get
            {
                return this._date;
            }

            set
            {
                this._date = value;
                RaisePropertyChanged("Date");
            }
        }


        // Public accessor of ModifiedDate property and raises a propertychanged notification.
        public string ModifiedDate
        {
            get
            {
                return this._modifiedDate;
            }

            set
            {
                this._modifiedDate = value;
                RaisePropertyChanged("ModifiedDate");
            }
        }


        // Public constructor to set a few variables and properties.
        public PropPost()
        {
        }


        // Public event property.
        public event PropertyChangedEventHandler PropertyChanged;


        // Protected void to raise a change notification in the application.
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        } 
    }
}
