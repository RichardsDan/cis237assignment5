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

        ////Get The Print String Array For All Items
        //public string[] GetPrintStringsForAllItems()
        //{
        //    //set a counter to be used
        //    int counter = 0;

        //    //If the wineItemsLength is greater than 0, create the array of strings
        //    if (wineItemsLength > 0)
        //    {
        //        //For each item in the collection
        //        foreach (Beverage wineItem in wineItems.Beverages)
        //        {
        //            //if the current item is not null.
        //            if (wineItem != null)
        //            {
        //                //Add the results of calling ToString on the item to the string array.
        //                allItemStrings[counter] = wineItem.ToString();
        //                counter++;
        //            }
        //        }
        //    }
        //    //Return the array of item strings
        //    return allItemStrings;
        //}

        //Find an item by it's Id

        public void UpdateItem()
        {

        }

        public string FindById(string id, BeverageDRichardsEntities beverages)
        {
            //Declare return string for the possible found item
            string returnString = null;
            Beverage wineToFind = beverages.Beverages.Find(id);

            if (wineToFind != null)
                returnString = wineToFind.id + " " + wineToFind.name + " " + wineToFind.pack + " " + wineToFind.price;

            //Return the returnString
            return returnString;
        }

    }
}
