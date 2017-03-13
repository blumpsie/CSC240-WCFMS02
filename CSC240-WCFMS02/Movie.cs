using System;

namespace CSC240_WCFMS02
{
    class Movie : Element
    {
        // DATA FIELDS
        private string title;
        private int year;
        private string starList;

        // Default constructer
        public Movie()
        {
            title = "";
            year = 0;
            starList = "";
        }

        // Sets and Gets the Movie title
        public string Title
        {
            set { title = value; }
            get { return title; }
        }

        // Sets and Gets the Movie year
        public int Year
        {
            set { year = value; }
            get { return year; }
        }

        // Sets and Gets the Movie starList
        public string StarList
        {
            set { starList = value; }
            get { return starList; }
        }

        // reads in the the user data and assigns it to the fields
        public override void readIn()
        {
            int numOfActors;
            
            Console.WriteLine("\nPlease enter the title of the movie:");
            this.title = Console.ReadLine().ToUpper();

            Console.WriteLine("\nPlease enter the year that {0} was realeased:", this.title);
            this.year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nHow many stars for {0} would you like to enter?", this.title);
            numOfActors = Convert.ToInt32(Console.ReadLine());

            if (numOfActors > 0)
            {
                Console.WriteLine("\nPlease enter the names for the stars of this movie:");
                for (int i = 1; i <= numOfActors; i++)
                {
                    Console.Write("\n#{0}:", i);
                    if (i < numOfActors)
                    {
                        this.starList += Console.ReadLine() + ";";
                    }
                    else
                    {
                        this.starList += Console.ReadLine();
                    }
                }
            }
        }

        // Displays the data for the Movie
        public override void display()
        {
            string[] tokens = this.starList.Split(';');
            
            Console.WriteLine("\nYear Realeased: {0}", this.year);
            Console.WriteLine("Actors that starred in this movie:");
            foreach (string star in tokens)
            {
                Console.WriteLine(star);
            }
        }

        // checks to see if a specific star was in the movie
        public bool hasStar(string starName)
        {
            string[] tokens = starList.Split(';');
            bool found = false;

            foreach (string star in tokens)
            {
                if (star.Equals(starName, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                }
            }

            return found;
        }

        public override bool equals(Element obj)
        {
            return this.title.Equals(((Movie)obj).Title);
        }

        // Creates a cloned object of the Movie object
        public override Element clone()
        {
            Movie theClone = new Movie();
            theClone.Title = this.title;
            theClone.Year = this.year;
            theClone.StarList = this.starList;
            return theClone;
        }
    }
}
