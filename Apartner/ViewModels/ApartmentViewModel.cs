using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Apartner.Models;
using Apartner.Views;
using Xamarin.Forms;
namespace Apartner.ViewModels
{
    public class ApartmentViewModel : BaseViewModel
    {
        public List<string> ApartmentsJson { get; set; }
        public Command LoadItemsCommand { get; set; }
        private Apartment m_Apartment;

        public Apartment Apartment
        {
            get
            {
                //m_Apartment.DeserializeApart(ApartmentsJson[0]);
                return m_Apartment;
            }
        }

        public ApartmentViewModel()
        {
            Title = "Browse";
            ApartmentsJson = new List<string>();
            if(m_Apartment == null)
            {
                m_Apartment = new Apartment();
            }
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


            MessagingCenter.Subscribe<SwipePage, Apartment>(this, "LikedApartment", async (obj, item) =>
            {
                var _item = item as Apartment;
                //Items.Add(_item);
                await DataStore.LikedApartmentAsync(_item.ToString());
            });

            MessagingCenter.Subscribe<SwipePage, Apartment>(this, "DislikedApartment", async (obj, item) =>
            {
                var _item = item as Apartment;
                //Items.Add(_item);
                await DataStore.DislikedApartmentAsync(_item.ToString());
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    ApartmentsJson.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void RemoveApartment()
        {
            if(ApartmentsJson.Count <= 2)
            {
                LoadItemsCommand.Execute(null);
            }
            ApartmentsJson.RemoveAt(0);
            m_Apartment.DeserializeApart(ApartmentsJson[0]);
        }


    }
}
