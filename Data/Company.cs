using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Data
{
    public class Company
    {
        public Company (CompanyType type, string name, FullName businessOwnerFullName)
        {
            if (!Enum.IsDefined(typeof(CompanyType), type))
                throw new ArgumentException("Тип компании не определён!"); 
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя компании не может быть пустым!");
            if (String.IsNullOrWhiteSpace(businessOwnerFullName.Name))
                throw new ArgumentNullException("Имя не может быть пустым!");
            if (String.IsNullOrWhiteSpace(businessOwnerFullName.SurName))
                throw new ArgumentNullException("Фамилия не может быть пустой!");
            Type = type;
            Name = name;
            BusinessOwnerFullName = businessOwnerFullName;
        }
        public CompanyType Type { get; set; }   
        public string Name { get; set; }
        public int Id { get; set; }
        public FullName BusinessOwnerFullName { get; set; }
        public Address HeadOfficeAddres { get; set; }

    }

    public struct Address
    {
        public string Country;
        public string SubjectOfFederation;
        public string City;
        public string District;
        public string Street;
        public string HouseNumber;
        public string PostalCode;
    }


    public struct FullName
    {
        public string Name;
        public string SurName;
        public string FathersName;
    }

    public enum CompanyType 
    {
        individualEntrepreneur, // ИП
        limitedLiabilityСompany // ООО
    }
}
