using System;
using System.Linq;
using ExpensesTracker.API.Data.Models;

namespace ExpensesTracker.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(this IServiceProvider services, ExpensesDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Currencies.Any())
            {
                return;
            }

            var currencies = new Currency[]
            {
                new Currency{
                    Id = new Guid("DD89A0F5-FD5B-40DD-B642-C4433DFF46F0"),
                    Code = "CAD",
                    Name="Canadian Dollar" 
                },
                new Currency{ 
                    Id = new Guid("DD89A0F5-FD5B-40DD-B642-C4433DFF46F1"),
                    Code = "USD", 
                    Name="US Dollar"
                },
            };

            var institutions = new Institution[]
            {
                new Institution{
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F700"),
                    Name = "Walmart",
                    InstitutionBranches = new InstitutionBranch[]
                    {
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F701"),
                            Name = "Billings Bridge"
                        },
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F702"),
                            Name = "Trainyards"
                        },
                    }
                },
                new Institution{ 
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F710"),
                    Name = "Loblaws",
                    InstitutionBranches = new InstitutionBranch[]
                    {
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F711"),
                            Name = "Independence Billings Bridge"
                        },
                    }
                },
                new Institution{ 
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F720"),
                    Name = "Farmboy",
                    InstitutionBranches = new InstitutionBranch[]
                    {
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F721"),
                            Name = "Bank"
                        },
                        new InstitutionBranch { 
                            Id = new Guid("15C67344-B7E1-4561-84B9-79586260F722"),
                            Name = "Trainyards"
                        },
                    }
                },
                new Institution{ 
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F730"),
                    Name = "Employer"
                },
                new Institution{
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F740"),
                    Name = "RBC"
                },
                new Institution{
                    Id = new Guid("15C67344-B7E1-4561-84B9-79586260F750"),
                    Name = "TD"
                }
            };

            var categories = new Category[]
            {
                new Category
                {
                    Id = new Guid("2DE545FF-48DF-4B95-A371-AB72D62F5300"),
                    Name = "Rent",
                }
            };

            context.Currencies.AddRange(currencies);
            context.Institutions.AddRange(institutions);
            context.SaveChanges();
        }
    }
}
