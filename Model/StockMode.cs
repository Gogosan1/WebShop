using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WebShop.DB;

namespace WebShop.Model
{
    public class StockMode
    {
        public ObservableCollection<Counterparty> counterparties = new ObservableCollection<Counterparty>();
        public ObservableCollection<ListOfGoodsInTheRequest> listOfGoodsInTheRequest = new ObservableCollection<ListOfGoodsInTheRequest>();
        public ObservableCollection<Request> listOfRequests = new ObservableCollection<Request>();
        public ObservableCollection<ListOfProductsInAssortment> listOfProductsInAssortment = new ObservableCollection<ListOfProductsInAssortment>();
        //public List<> список продуктов в заявке 2 

        public StockMode() 
        {
            Update();
        }

        private void Update()
        {

        }
    }
}
