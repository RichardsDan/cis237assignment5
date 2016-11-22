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

        //Constuctor.
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

        // Allows user to change information for any item in the database, excluding the id
        public void UpdateItem(UserInterface ui)
        {
            // Gets item to be updated from user
            Beverage updateWine = ui.GetItemForUpdate(wineItems);

            // Ensures wine actually exists and is in the database
            if (updateWine != null)
            {
                int choice = ui.DisplayUpdateMenuAndGetResponse();
                
                while (choice != 4)
                {
                    switch(choice)
                    {
                        case 1:
                            // Change the description/name of the wine
                            updateWine.name = ui.GetItemDescription();
                            break;
                        case 2:
                            // Change the pack of the wine
                            updateWine.pack = ui.GetItemPack();
                            break;
                        case 3:
                            // Change the price of the wine
                            updateWine.price = ui.GetItemPrice();
                            break;
                    }
                    choice = ui.DisplayUpdateMenuAndGetResponse();
                }
                // Save changes made to the item and display a messgage saying the item was updated
                wineItems.SaveChanges();
                ui.DisplayItemUpdated();
            }
            else
            {
                ui.DisplayItemFoundError();
            }
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

        // Allows user to delete an item from the list
        public void DeleteItem(UserInterface ui)
        {
            // Gets the wine to be deleted from the user
            Beverage wineToDelete = wineItems.Beverages.Find(ui.GetItemID());

            // Checks to see if a wine is selected, then double checks that the user wants to delete this wine
            if (wineToDelete != null)
            {
                int choice = ui.ItemToDeleteAssurance(wineToDelete);

                // Removes wine if the user says yes
                if (choice == 1)
                        wineItems.Beverages.Remove(wineToDelete);
            }
            else
            {
                ui.DisplayItemFoundError();
            }
            // Save changes made to the database then outputs a message saying the wine has been deleted
            wineItems.SaveChanges();
            ui.DisplayItemDeleted();
        }
    }
}
