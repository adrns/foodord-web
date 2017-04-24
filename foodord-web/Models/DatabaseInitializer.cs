using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace foodord_web.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<FoodOrderingContext>
    {
        protected override void Seed(FoodOrderingContext context)
        {
            var categories = new List<Category>
            {
                new Category{Name="Hamburger"},
                new Category{Name="Pizza"},
                new Category{Name="Italok"},
                new Category{Name="Desszertek"}
            };

            var foods = new List<Food>
            {
                new Food { Category=categories.ElementAt(0), Name="Camembert burger \"L\"", Description="Nagy buciban rántott camembert, jégsaláta, hagymalekvár", Price=1720, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(0), Name="Camembert burger \"M\"", Description="Kis buciban rántott camembert, jégsaláta, hagymalekvár", Price=1090, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(0), Name="Dupla csirkeburger", Description="200g csirkemell filé kis buciban", Price=1290, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(0), Name="Dupla marhaburger", Description="200g marhahúspogácsa kis buciban ", Price=1420, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(1), Name="Bolognai pizza", Description="Bolognai alap, mozzarella", Price=1550, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(1), Name="Calzone", Description="hajtott pizza, pizzaszósz, sonka, gomba, tükörtojás, mozzarella", Price=1790, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(1), Name="Caprese", Description="olivaolaj, mozarella, koktélparadicsom, ruccola, pesto", Price=1790, Spicy=false, Vegetarian=true },
                new Food { Category=categories.ElementAt(1), Name="Hawaii", Description="pizzaszósz, sonka, kukorica, ananász, mozzarella", Price=1450, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola 0,33l", Description="", Price=290, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola 0,5l", Description="", Price=350, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola 1,25l", Description="", Price=450, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola light 0,33l", Description="", Price=290, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola light 0,5l", Description="", Price=350, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola light 1,25l", Description="", Price=450, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola zero 0,33l", Description="", Price=290, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(2), Name="Coca-Cola zero 0,5l", Description="", Price=350, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(3), Name="Csokipudingos palacsinta", Description="", Price=250, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(3), Name="Csokis brownie", Description="", Price=690, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(3), Name="Diós palacsinta", Description="", Price=190, Spicy=false, Vegetarian=false },
                new Food { Category=categories.ElementAt(3), Name="Fahéjas palacsinta", Description="", Price=190, Spicy=false, Vegetarian=false }
            };

            categories.ForEach(e => context.Categories.Add(e));
            foods.ForEach(e => context.Foods.Add(e));

            context.SaveChanges();
        }
    }
}