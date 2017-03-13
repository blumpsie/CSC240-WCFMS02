using System;

namespace CSC240_WCFMS02
{
    class Movie
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

        // Returns the title of the Movie
        public string getTitle()
        {
            return title;
        }

        // Returns the year the Movie was released
        public int getYear()
        {
            return year;
        }

        // reads in the the user data and assigns it to the fields
        public void readIn()
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
        public void display()
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
    }
}
