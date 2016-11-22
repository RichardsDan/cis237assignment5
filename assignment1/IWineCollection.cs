using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    interface IWineCollection
    {
        void AddNewItem(string id, string description, string pack, decimal price);

        string FindById(string id);
    }
}
