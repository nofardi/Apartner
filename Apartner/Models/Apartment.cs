using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Apartner.Models
{
    public class Apartment : INotifyPropertyChanged
    {
        private string m_Address;
        private int m_Price;
        private int m_RoommatesNum;
        private int m_RoomsNum;
        private double m_EntryDate;
        private List<string> m_Properties;
        private List<string> m_Images;
        private List<Roommate> m_Roommates;

        public Apartment()
        {
            
        }

        //public Apartment(string i_Address, int i_Price, int i_RoomsNumber, int i_RoommatesNum, List<string> i_Properties, List<string> i_Images, double i_EntryDate)
        //{
        //    m_Address = i_Address;
        //    m_Price = i_Price;
        //    m_RoomsNum = i_RoomsNumber;
        //    m_RoommatesNum = i_RoommatesNum;
        //    m_EntryDate = i_EntryDate;
        //    m_Properties = new List<string>(i_Properties);
        //    m_Images = new List<string>(i_Images);
        //}

        public string Address
        {
            get => m_Address;
            set
            {
                m_Address = value;
                OnPropertyChanged("Address");
            }
        }
        public int Price
        {
            get => m_Price;
            set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }
        public int RoomsNumber { get => m_RoomsNum; set => m_RoomsNum = value; }
        public double EntryDate
        {
            get => m_EntryDate;
            set
            {
                m_EntryDate = value;
                OnPropertyChanged("EntryDate");
            }
        }
        public int RoommatesNumber
        {
            get => m_RoommatesNum;
            set
            {
                m_RoommatesNum = value;
                OnPropertyChanged("RoommatesNumber");
            }
        }
        public List<string> Properties { get => m_Properties; set => m_Properties = value; }
        public List<string> Images { get => m_Images; set => m_Images = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string i_PropertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(i_PropertyName));
            }
        }

        public void DeserializeApart(string i_AparmentJsonStr)
        {
            Apartment tempApart = JsonConvert.DeserializeObject<Apartment>(i_AparmentJsonStr);


            this.Address = tempApart.Address;
            this.Price = tempApart.Price;
            this.EntryDate = tempApart.EntryDate;
            this.RoommatesNumber = tempApart.RoommatesNumber;

            if(this.Properties == null)
            {
                this.Properties = new List<string>();
            }
            if(Images == null)
            {
                this.Images = new List<string>();
            }
            this.Properties.Clear();
            foreach(string prop in tempApart.Properties)
            {
                this.Properties.Add(prop);
            }

            this.Images.Clear();
            foreach(string image in tempApart.Images)
            {
                this.Images.Add(image);
            }

        }

    }
}
