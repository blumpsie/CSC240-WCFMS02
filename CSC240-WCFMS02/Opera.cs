using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS02
{
    class Opera : Element
    {
        // DATA FIELDS
        private string title;
        private string composer;
        private string performanceDate;

        // Default constructer
        public Opera()
        {
            title = "";
            composer = "";
            performanceDate = "";
        }

        // Sets and Gets the Opera title
        public string Title
        {
            set { title = value; }
            get { return title; }
        }

        // Sets and Gets the composer of the Opera
        public string Composer
        {
            set { composer = value; }
            get { return composer; }
        }

        // Sets and Gets the date that the Opera wa performed
        public string PerformanceDate
        {
            set { performanceDate = value; }
            get { return performanceDate; }
        }

        // reads in the the user data and assigns it to the fields
        public override void readIn()
        {
            Console.WriteLine("\nPlease enter the title of the opera:");
            this.title = Console.ReadLine().ToUpper();

            Console.WriteLine("\nPlease enter the composer of {0}:", this.title);
            this.composer = Console.ReadLine();

            Console.WriteLine("\nOn what date was {0} performed", this.title);
            this.performanceDate = Console.ReadLine();
        }

        // Displays the data for the Opera
        public override void display()
        {
            Console.WriteLine("\nComposer: {0}", this.composer);
            Console.WriteLine("Date Performed: {0}", this.performanceDate);
        }

        public override bool equals(Element obj)
        {
            return this.title.Equals(((Opera)obj).Title);
        }

        // Creates a cloned object of the Opera object
        public override Element clone()
        {
            Opera theClone = new Opera();
            theClone.Title = this.title;
            theClone.Composer = this.composer;
            theClone.PerformanceDate = this.performanceDate;
            return theClone;
        }
    }
}
