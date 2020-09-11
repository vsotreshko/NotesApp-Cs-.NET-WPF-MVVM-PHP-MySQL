using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Custom_types
{
    public class myBindingList<Note> : BindingList<Note>
    {
        protected override void RemoveItem(int itemIndex)
        {
            //itemIndex = index of item which is going to be removed
            //get item from binding list at itemIndex position
            Note deletedItem = this.Items[itemIndex];

            if (BeforeRemove != null)
            {
                //raise event containing item which is going to be removed
                BeforeRemove(deletedItem);
            }

            //remove item from list
            base.RemoveItem(itemIndex);
        }

        public delegate void myIntDelegate(Note deletedItem);
        public event myIntDelegate BeforeRemove;
    }
}
