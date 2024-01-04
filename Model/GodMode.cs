using System;
using System.Collections.ObjectModel;
using System.Linq;
using WebShop.DB;

namespace WebShop.Model
{
    public class GodMode
    {
        public ObservableCollection<Shop> shops = new ObservableCollection<Shop>();
        public ObservableCollection<Stok> stoks = new ObservableCollection<Stok>();
        public ObservableCollection<Counterparty> counterparties = new ObservableCollection<Counterparty>();
        public ObservableCollection<Good> products = new ObservableCollection<Good>();
        
        public GodMode()
        {
            Update();
        }

        private void Update()
        {
            shops.Clear();
            stoks.Clear();
            counterparties.Clear();
            products.Clear();
            GetShops();
            GetStoks();
            GetCounterparties();
            GetProducts();
        }

        private void GetShops()
        {
            using (WebShopContext webShopContext = new WebShopContext())
            {
                int i = 1;
                var structuralSubdivisions = webShopContext.StructuralSubdivisions.ToList();
                foreach (var subdvivsion in structuralSubdivisions)
                {
                    if (subdvivsion.IdOfType == 2)
                    {
                        shops.Add(new Shop(i, subdvivsion.Name, subdvivsion.Address));
                        i++;
                    }
                }
            }
        }

        private void GetStoks()
        {
            using (WebShopContext webShopContext = new WebShopContext())
            {
                int i = 1;
                var structuralSubdivisions = webShopContext.StructuralSubdivisions.ToList();
                foreach (var subdvivsion in structuralSubdivisions)
                {
                    if (subdvivsion.IdOfType == 1)
                    {
                        stoks.Add(new Stok(i, subdvivsion.Name, subdvivsion.Address));
                        i++;
                    }
                }
            }
        }

        private void GetCounterparties()
        {
            using (WebShopContext context = new WebShopContext())
            {
                var counterparties_local = context.Counterparties.ToList();
                foreach (var counterparty in counterparties_local)
                {
                    counterparties.Add(counterparty);
                }
            }
        }

        private void GetProducts()
        {
            using (var context = new WebShopContext())
            {
                var goods = context.Goods.ToList();
                var units = context.Units.ToList();
                foreach(var good in goods)
                {
                    products.Add(good);
                }
            }
        }

        public void AddProduct()
        {

        }

        /*public void AddCounterparty(long inn, string banksName, long currentAccountNumber, string organizationName)
        {
            using (var webShopContext = new WebShopContext())
            {
                // воткнуть проверки
                if (String.IsNullOrWhiteSpace(banksName) || String.IsNullOrWhiteSpace(organizationName))
                    throw new Exception("Поля не могут быть пустыми!");
                var counterparty = new Counterparty();
                counterparty.Inn = inn;
                counterparty.BanksName = banksName;
                counterparty.CurrentAccountNumber = currentAccountNumber;
                counterparty.Name = organizationName;
                webShopContext.Add(counterparty);
                webShopContext.SaveChanges();
            }
            Update();
        }
*/
/*        public void DeleteCounterparty(long Id)
        {
            using (var webShopContext = new WebShopContext())
            {
                foreach(var counterparty in counterparties)
                {
                    if (counterparty.Id == Id)
                    {
                        counterparties.Remove(counterparty);
                        webShopContext.Remove(counterparty);
                        webShopContext.SaveChanges();
                        break;
                    }
                }
            }
            Update();
        }*/


        public void AddStructuralSubdivision(int typeId, string name, string address, long orgId)
        {
            using (var webShopContext = new WebShopContext())
            {
                if (CheckSubdivisionNameExist(name))
                    throw new Exception("Подразделение с таким именем уже существует");
                if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(address))
                    throw new Exception("Значения полей не могут быть пустыми");
                var subd = webShopContext.StructuralSubdivisions;
                var newStrSubd = new StructuralSubdivision();
                newStrSubd.IdOrganization = orgId;
                newStrSubd.Address = address;
                newStrSubd.Name = name;
                newStrSubd.IdOfType = (long)typeId;
                subd.Add(newStrSubd);
                webShopContext.SaveChanges();
            }
            Update();
        }

        public void DeleteSturcturalSubdivision(string name)
        {
            using (var webShopContext = new WebShopContext())
            {
                var strSbd = webShopContext.StructuralSubdivisions;
                foreach(var subd in strSbd)
                {
                    if (subd.Name == name)
                        webShopContext.StructuralSubdivisions.Remove(subd);
                    webShopContext.SaveChanges();
                }
            }
            Update();
        }

        private bool CheckSubdivisionNameExist(string name)
        {
            using (WebShopContext webShopContext = new WebShopContext())
            {
                var structuralSubd = webShopContext.StructuralSubdivisions;
                foreach( var  subdvivsion in structuralSubd)
                {
                    if (subdvivsion.Name == name)
                        return true;
                }
                return false;
            }
            
        }
    }
}
