using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Apartner.Models;
using Xamarin.Forms;
namespace Apartner.ViewModels
{
    public class ApartmentViewModel : BaseViewModel
    {
        public ObservableCollection<Apartment> Apartments { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Apartment Apartment { get => Apartments[0]; }

        public ApartmentViewModel()
        {
            Title = "Browse";
            Apartments = new ObservableCollection<Apartment>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var _item = item as Item;
            //    Items.Add(_item);
            //    await DataStore.AddItemAsync(_item);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Apartments.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Apartments.Add(item);
                }
                Apartments[0].PropertyChanged += Apartment.SetPropertyChangedForAll;
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
            Apartments.RemoveAt(0);
        }


    }
}
