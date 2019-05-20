using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace ExpediaDownload.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Listing : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Listing(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            DateAdded = DateTime.Now;
        }


        private DateTime _DateAdded;
        public DateTime DateAdded
        {
            get { return _DateAdded; }
            set { SetPropertyValue<DateTime>("DateAdded", ref _DateAdded, value); }
        }


        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set { SetPropertyValue<decimal>("Price", ref _Price, value); }
        }


        private DateTime _ListingDate;
        public DateTime ListingDate
        {
            get { return _ListingDate; }
            set { SetPropertyValue<DateTime>("ListingDate", ref _ListingDate, value); }
        }



        [Association("Resort-Listing", typeof(Resort))]
        public Resort Resort
        {
            get { return this.GetPropertyValue<Resort>("Resort"); }
            set { this.SetPropertyValue("Resort", value); }
        }



    }
}