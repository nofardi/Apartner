using System.Collections.Generic;
using System.ComponentModel;

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

        public Apartment(string i_Address, int i_Price, int i_RoomsNumber, int i_RoommatesNum, List<string> i_Properties, List<string> i_Images, double i_EntryDate)
        {
            m_Address = i_Address;
            m_Price = i_Price;
            m_RoomsNum = i_RoomsNumber;
            m_RoommatesNum = i_RoommatesNum;
            m_EntryDate = i_EntryDate;
            m_Properties = i_Properties;
            m_Images = i_Images;
        }

        public string Address { get => m_Address; set => m_Address = value; }
        public int Price { get => m_Price; set => m_Price = value; }
        public int RoomsNumber { get => m_RoomsNum; set => m_RoomsNum = value; }
        public double EntryDate { get => m_EntryDate; set => m_EntryDate = value; }
        public int RoommatesNumber { get => m_RoommatesNum; set => m_RoommatesNum = value; }
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

        public void SetPropertyChangedForAll(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Address");
            OnPropertyChanged("Price");
            OnPropertyChanged("EntryDate");
            OnPropertyChanged("Properties");
        }
    }
}
