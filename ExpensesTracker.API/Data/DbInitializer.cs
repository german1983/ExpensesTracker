using System;
using System.Linq;
using ExpensesTracker.API.Data.Models;

namespace ExpensesTracker.API.Data
{
    public static class DbInitializer
    {
        public static void InitializeDatabase(this IServiceProvider services, ExpensesDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Currencies.Any())
            {
                // If there are Currencies we assume the DB has been seeded
                return;
            }

            var currencies = new Currency[]
            {
                new Currency{
                    Id = new Guid("DD89A0F5-FD5B-40DD-B642-C4433DFF46F0"),
                    Code = "CAD",
                    Name="Canadian Dollar",
                },
                new Currency{ 
                    Id = new Guid("DD89A0F5-FD5B-40DD-B642-C4433DFF46F1"),
                    Code = "USD", 
                    Name="US Dollar",
                },
            };

            var institutions = new Institution[]
            {
                new Institution{
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F700"),
                    Name = "Walmart",
                    IsPublic = true,
                    InstitutionBranches = new InstitutionBranch[]
                    {
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F701"),
                            Name = "Billings Bridge",
                        },
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F702"),
                            Name = "Trainyards",
                        },
                    }
                },
                new Institution{ 
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F710"),
                    Name = "Loblaws",
                    IsPublic = true,
                    InstitutionBranches = new InstitutionBranch[]
                    {
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F711"),
                            Name = "Independence Billings Bridge",
                        },
                    }
                },
                new Institution{ 
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F720"),
                    Name = "Farmboy",
                    IsPublic = true,
                    InstitutionBranches = new InstitutionBranch[]
                    {
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F721"),
                            Name = "Bank",
                        },
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F722"),
                            Name = "Trainyards",
                        },
                    }
                },
                new Institution{ 
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F730"),
                    IsPublic = true,
                    Name = "Employer",
                },
                new Institution{
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F740"),
                    IsPublic = true,
                    Name = "RBC",
                },
                new Institution{
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F750"),
                    IsPublic = true,
                    Name = "TD",
                }
            };

            var incomeCategory = new Category
            {
                IsPublic = true,
                Id = new Guid("7ED898B5-2AFC-4E9C-A78E-09801BBBF300"),
                Name = "Income",
            };

            var wageCategory = new Category
            {
                Id = new Guid("7ED898B5-2AFC-4E9C-A78E-09801BBBF301"),
                IsPublic = true,
                Name = "Wage",
                ParentCategory = incomeCategory,
            };

            var basicsCategory = new Category
            {
                Id = new Guid("7ED898B5-2AFC-4E9C-A78E-09801BBBF310"),
                IsPublic = true,
                Name = "Basics"
            };

            var feedingCategory = new Category
            {
                Id = new Guid("7ED898B5-2AFC-4E9C-A78E-09801BBBF311"),
                IsPublic = true,
                Name = "Feeding",
                ParentCategory = basicsCategory
            };

            var housingCategory = new Category
            {
                Id = new Guid("7ED898B5-2AFC-4E9C-A78E-09801BBBF320"),
                IsPublic = true,
                Name = "Housing",
            };


            var concepts = new Concept[]
            {
                new Concept
                {
                    Id = new Guid("2DE545FF-48DF-4B95-A371-AB72D62F5300"),
                    Description = "Rent",
                    IsPublic = true,
                    Category = housingCategory,
                },
                new Concept
                {
                    Id = new Guid("2DE545FF-48DF-4B95-A371-AB72D62F5301"),
                    Description = "Salary",
                    IsPublic = true,
                    Category = wageCategory,
                },
                new Concept
                {
                    Id = new Guid("2DE545FF-48DF-4B95-A371-AB72D62F5302"),
                    Description = "Dairy Products",
                    IsPublic = true,
                    Category = feedingCategory
                },
                new Concept
                {
                    Id = new Guid("2DE545FF-48DF-4B95-A371-AB72D62F5303"),
                    Description = "Meats",
                    IsPublic = true,
                    Category = feedingCategory
                }
            };

            context.Concepts.AddRange(concepts);
            context.Currencies.AddRange(currencies);
            context.Institutions.AddRange(institutions);
            context.SaveChanges();
        }
    }
}
