using Hotel.Model;
using Hotel.Property;
using Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hotel.ViewModel
{
   public class ExtraServicesVM : BasePropertyChanged
    {
    
        private ExtraServiceRepository repo = new ExtraServiceRepository();
        private ObservableCollection<ExtraService> extraServices;
        public ExtraServicesVM()
        {
            this.extraServices = ReturnCollection();
        }

        private float price;

        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
                NotifyPropertyChanged("Price");
            }
        }

        private String type;

        public String Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                NotifyPropertyChanged("Type");
            }
        }

        public ObservableCollection<ExtraService> ReturnCollection()
        {
            var list = new List<ExtraService>();
            list = repo.GetAll();
            var oc = new ObservableCollection<ExtraService>();
            foreach (var item in list)
            {
                oc.Add(item);
            }

            return oc;
        }
        public ObservableCollection<ExtraService> ExtraServices
        {
            get
            {
                return ReturnCollection();
            }
            set
            {
                this.extraServices = ReturnCollection();
            }
        }
    }
}
