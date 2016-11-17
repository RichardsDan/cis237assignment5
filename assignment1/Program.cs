//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            BeverageDRichardsEntities beverageDRichardsEntities = new BeverageDRichardsEntities();

            WineItemCollection wineItems = new WineItemCollection(beverageDRichardsEntities);

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        userInterface.DisplayAllItems(beverageDRichardsEntities);
                        break;
                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = wineItems.FindById(searchQuery, beverageDRichardsEntities);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                    case 3:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (wineItems.FindById(newItemInformation[0], beverageDRichardsEntities) == null)
                        {
                            wineItems.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], decimal.Parse(newItemInformation[3]));

                            beverageDRichardsEntities.SaveChanges();

                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                    case 4:
                        // Update an Item in the List

                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
