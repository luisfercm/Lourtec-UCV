using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemoVS
{
    
    public struct BillingDetails
    {
        //public BillingDetails(string name, int myVar , string publicField, string accountNumber,int publicVar  )
        //{
        //    this.name = name;
        //    this.myVar = myVar;
        //    this.publicField = publicField;
        //    this.AccountNumber = accountNumber;
            
        //}

        //atajo "ctor"

        //public BillingDetails()
        //{

        //}

        private string name;

        public string publicField;

        // Forma explicita
        public string Name
        {
            get {
                return name;
            }
            set
            {
                name = value;
            }
        }

        // Forma implicita
        public string AccountNumber
        {
            get;
            set;
        }

        // escribir prop + tab
        //public int MyProperty { get; set; }

        public int MyPropertyProp { get; set; }


        // escribir propa + tab




        // escribir propfull + tab

        private int myVar;

        public int MyPropertyFull
        {
            get { return myVar; }
            set { myVar = value; }
        }


        // escribir propg+ tab

        public int MyPropertyG { get; private set; }




    }
}
