namespace Park.Data.Migrations
{
    using Park.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ParkContext context)
        {
            context.CountrySet.AddOrUpdate(GenerateCountry());
            context.StateSet.AddOrUpdate(GenerateState());
            context.CitySet.AddOrUpdate(GenerateCity());
            context.CustomerSet.AddOrUpdate(GenerateCustomers());
        }
        private Country[] GenerateCountry()
        {
            Country[] _countries = new Country[]{
                new Country()
                {
                    ID=1,
                    CountryName="INDIA",
                    CountryCode="IN",  
                    IsDeleted = false
                }
            };
            return _countries;
        }
        private State[] GenerateState()
        {
            State[] _statees = new State[]{
                new State()
                {  ID=1,
                    CountryId=1,
                    StateName="Andaman and Nicobar Islands",  
                    IsDeleted = false
                },
                new State()
                {  ID=2,
                    CountryId=1,
                    StateName="Andhra Pradesh",  
                    IsDeleted = false
                },
                new State()
                {  ID=3,
                    CountryId=1,
                    StateName="Arunachal Pradesh",  
                    IsDeleted = false
                },
                new State()
                {  ID=4,
                    CountryId=1,
                    StateName="Assam",  
                    IsDeleted = false
                },
                new State()
                {  ID=5,
                    CountryId=1,
                    StateName="Bihar",  
                    IsDeleted = false
                },
                new State()
                {  ID=6,
                    CountryId=1,
                    StateName="Chandigarh",  
                    IsDeleted = false
                },
                new State()
                {  ID=7,
                    CountryId=1,
                    StateName="Chhattisgarh",  
                    IsDeleted = false
                },
                new State()
                {  ID=8,
                    CountryId=1,
                    StateName="Dadra and Nagar Haveli",  
                    IsDeleted = false
                },
                new State()
                {  ID=9,
                    CountryId=1,
                    StateName="Daman and Diu",  
                    IsDeleted = false
                },
                new State()
                {  ID=10,
                    CountryId=1,
                    StateName="Delhi",  
                    IsDeleted = false
                },
                new State()
                {  ID=11,
                    CountryId=1,
                    StateName="Goa",  
                    IsDeleted = false
                },
                new State()
                { ID=12,
                    CountryId=1,
                    StateName="Gujarat",  
                    IsDeleted = false
                },
                new State()
                { ID=13,
                    CountryId=1,
                    StateName="Haryana",  
                    IsDeleted = false
                },
                new State()
                { ID=14,
                    CountryId=1,
                    StateName="Himachal Pradesh",  
                    IsDeleted = false
                },
                new State()
                { ID=15,
                    CountryId=1,
                    StateName="Jammu and Kashmir",  
                    IsDeleted = false
                },
                new State()
                { ID=16,
                    CountryId=1,
                    StateName="Jharkhand",  
                    IsDeleted = false
                },
                new State()
                { ID=17,
                    CountryId=1,
                    StateName="Karnataka",  
                    IsDeleted = false
                },
                new State()
                { ID=18,
                    CountryId=1,
                    StateName="Kenmore",  
                    IsDeleted = false
                },
                new State()
                { ID=19,
                    CountryId=1,
                    StateName="Kerala",  
                    IsDeleted = false
                },
                new State()
                { ID=20,
                    CountryId=1,
                    StateName="Lakshadweep",  
                    IsDeleted = false
                },
                new State()
                { ID=21,
                    CountryId=1,
                    StateName="Madhya Pradesh",  
                    IsDeleted = false
                },
                new State()
                { ID=22,
                    CountryId=1,
                    StateName="Maharashtra",  
                    IsDeleted = false
                },
                new State()
                { ID=23,
                    CountryId=1,
                    StateName="Manipur",  
                    IsDeleted = false
                },
                new State()
                { ID=24,
                    CountryId=1,
                    StateName="Meghalaya",  
                    IsDeleted = false
                },
                new State()
                { ID=25,
                    CountryId=1,
                    StateName="Mizoram",  
                    IsDeleted = false
                },
                new State()
                { ID=26,
                    CountryId=1,
                    StateName="Nagaland",  
                    IsDeleted = false
                },
                new State()
                { ID=27,
                    CountryId=1,
                    StateName="Narora",  
                    IsDeleted = false
                },
                new State()
                { ID=28,
                    CountryId=1,
                    StateName="Natwar",  
                    IsDeleted = false
                },
                new State()
                { ID=29,
                    CountryId=1,
                    StateName="Odisha",  
                    IsDeleted = false
                },
                new State()
                { ID=30,
                    CountryId=1,
                    StateName="Paschim Medinipur",  
                    IsDeleted = false
                },
                new State()
                { ID=31,
                    CountryId=1,
                    StateName="Pondicherry",  
                    IsDeleted = false
                },
                new State()
                { ID=32,
                    CountryId=1,
                    StateName="Punjab",  
                    IsDeleted = false
                },
                new State()
                { ID=33,
                    CountryId=1,
                    StateName="Rajasthan",  
                    IsDeleted = false
                },
                new State()
                { ID=34,
                    CountryId=1,
                    StateName="Sikkim",  
                    IsDeleted = false
                },
                new State()
                { ID=35,
                    CountryId=1,
                    StateName="Tamil Nadu",  
                    IsDeleted = false
                },
                new State()
                { ID=36,
                    CountryId=1,
                    StateName="Telangana",  
                    IsDeleted = false
                },
                new State()
                { ID=37,
                    CountryId=1,
                    StateName="Tripura",  
                    IsDeleted = false
                },
                new State()
                { ID=38,
                    CountryId=1,
                    StateName="Uttar Pradesh",  
                    IsDeleted = false
                },
                new State()
                { ID=39,
                    CountryId=1,
                    StateName="Uttarakhand",  
                    IsDeleted = false
                },
                new State()
                { ID=40,
                    CountryId=1,
                    StateName="Vaishali",  
                    IsDeleted = false
                },
                new State()
                { ID=41,
                    CountryId=1,
                    StateName="West Bengal",  
                    IsDeleted = false
                } 
            };
            return _statees;
        }
        private City[] GenerateCity()
        {
            City[] _cities = new City[]{
                new City()
                {ID=1,
                    StateId=22,
                    CityName="Nagpur",  
                    IsDeleted = false
                }
            };
            return _cities;
        }
        private Customer[] GenerateCustomers()
        {
            Customer[] _users = new Customer[]{
                new Customer()
                {   ID=1,
                    Name="Raju 1",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                    ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=2,
                    Name="Raju 2",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                    ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=3,
                    Name="Raju 3",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                       ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=4,
                    Name="Raju 4",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                       ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=5,
                    Name="Raju 5",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                       ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=6,
                    Name="Raju 6",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                       ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=7,
                    Name="Raju 7",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                      ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=8,
                    Name="Raju 8",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                       ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=9,
                    Name="Raju 9",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                        ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=10,
                    Name="Raju 10",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                        ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                },
                new Customer()
                {   ID=11,
                    Name="Raju 11",
                    Email="rajukumar54321@gmail.com",
                    Phone="123456789",
                    DOB =System.DateTime.Now.Date,
                    CityId = 1,
                       ProfileImageURL = "Images/ProfilePic/6aa928e8-faee-4930-b2e9-6d760e6263a8.Jpeg",
                    IsDeleted = false
                }
            };
            return _users;
        }
    }
}
