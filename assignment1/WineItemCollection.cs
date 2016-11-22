//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemCollection : IWineCollection
    {
        //Private Variables
        BeverageDRichardsEntities wineItems;

        //Constuctor. Must pass the size of the collection.
        public WineItemCollection(BeverageDRichardsEntities wines)
        {
            wineItems = wines;
        }

        //Add a new item to the collection
        public void AddNewItem(string id, string description, string pack, decimal price)
        {
            //Add a new WineItem to the collection.
            Beverage newWine = new Beverage();

            newWine.id = id;
            newWine.name = description;
            newWine.pack = pack;
            newWine.price = price;

            wineItems.Beverages.Add(newWine);
        }

       

        public void UpdateItem(UserInterface ui)
        {
            Beverage updateWine = ui.GetItemForUpdate(wineItems);

            if (updateWine != null)
            {
                int choice = ui.DisplayUpdateMenuAndGetResponse();
                
                while (choice != 4)
                {
                    switch(choice)
                    {
                        // Change the description/name of the wine
                        case 1:
                            updateWine.name = ui.GetItemDescription();
                            break;
                        case 2:
                            updateWine.pack = ui.GetItemPack();
                            break;
                        case 3:
                            updateWine.price = ui.GetItemPrice();
                            break;
                    }
                    choice = ui.DisplayUpdateMenuAndGetResponse();
                }
                wineItems.SaveChanges();
            }
            else
            {
                ui.DisplayItemFoundError();
            }

            ui.DisplayItemUpdated();
        }

        //Find an item by it's Id
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;
            Beverage wineToFind = wineItems.Beverages.Find(id);

            if (wineToFind != null)
                returnString = wineToFind.id + " " + wineToFind.name + " " + wineToFind.pack + " " + wineToFind.price;

            //Return the returnString
            return returnString;
        }

        public void DeleteItem(UserInterface ui)
        {
            Beverage wineToDelete = wineItems.Beverages.Find(ui.GetItemID());

            if (wineToDelete != null)
            {
                int choice = ui.ItemToDeleteAssurance(wineToDelete);

                if (choice == 1)
                        wineItems.Beverages.Remove(wineToDelete);
            }
            else
            {
                ui.DisplayItemFoundError();
            }

            wineItems.SaveChanges();
        }
    }
}
