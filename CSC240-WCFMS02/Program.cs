using System;

namespace CSC240_WCFMS02
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementSet theList = new ElementSet();
            /*
            Movie movie = new Movie();
            Console.WriteLine(movie.ToString());
            */
            // present the menu for user to choose from
            // and process their choice
            bool terminate = false;
            do
            {
                bool validChoice = false;
                string userChoice;
                do
                {
                    Console.Write("\nWEST CHESTER FABULOUS MOVIE SOCIETY DATA MENU\n"
                                 + "1 - Add a Movie or an Opera\n"
                                 + "2 - Display the titles for all of the Movies\n"
                                 + "3 - Display the titles for all of the Operas\n"
                                 + "4 - Display the data for a particular Movie\n"
                                 + "5 - Display the data for a particular Opera\n"
                                 + "6 - Edit the data for a particular Movie or Opera\n"
                                 + "7 - Remove a particular Movie or Opera\n"
                                 + "8 - Quit the program\n");
                    userChoice = Console.ReadLine();

                    if (userChoice[0] != '1' ||
                        userChoice[0] != '2' ||
                        userChoice[0] != '3' ||
                        userChoice[0] != '4' ||
                        userChoice[0] != '5' ||
                        userChoice[0] != '6' ||
                        userChoice[0] != '7' ||
                        userChoice[0] != '8')
                    {
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid choice. Please try again.");
                    }

                } while (!validChoice);

                
                switch (userChoice[0])
                {
                    case '1':
                        Console.WriteLine("\nWhich would you like to add (Movie/Opera)?");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice[0] == 'M')
                        {
                            addMovie(theList);
                        }
                        else if (choice[0] == 'O')
                        {
                            addOpera(theList);
                        }
                        else
                        {
                            Console.WriteLine("\nNot a valid choice.");
                        }
                        break;
                    case '2':
                        displayMovieTitles(theList);
                        break;
                    case '3':
                        displayOperaTitles(theList);
                        break;
                    case '4':
                        Console.WriteLine("\nWhat Movie would you like to see information for?");
                        string title = Console.ReadLine().ToUpper();
                        displayMovie(theList, title);
                        break;
                    case '5':
                        Console.WriteLine("\nWhat Opera would you like to see information for?");
                        title = Console.ReadLine().ToUpper();
                        displayOpera(theList, title);
                        break;
                    case '6':
                        Console.WriteLine("Not Implemented yet.");
                        break;
                    case '7':
                        Console.WriteLine("Not Implemented yet.");
                        break;
                    case '8':
                        Console.WriteLine("\nAre you sure (Y/N)?");
                        string exitChoice = Console.ReadLine().ToUpper();
                        if (exitChoice[0] == 'Y')
                        {
                            terminate = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nNot a valid choice. Please choose again.");
                        break;
                }
            } while (!terminate);
        }

        // Sorts an array of Movie objects using bubble sort
        public static void bubbleSort(Movie[] movies)
        {
            bool swapped = true;
            int j = 0;
            Movie temp;

            while(swapped)
            {
                swapped = false;
                j++;

                for (int i = 0; i < movies.Length - j; i++)
                {
                    if (String.Compare(movies[i].Title, movies[i + 1].Title, true) > 0)
                    {
                        temp = movies[i];
                        movies[i] = movies[i + 1];
                        movies[i + 1] = temp;

                        swapped = true;
                    }
                }
            }
        }

        // Display's the title of all the movies
        public static void displayMovieTitles(ElementSet anElementSet)
        {
            Element currObject;
            Movie movie;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                
                if (currObject.getClassName().Equals("Movie"))
                {
                    movie = (Movie)currObject; // casts the currentObject as Movie Object
                                               // so that the title can be accessed
                    Console.WriteLine(movie.Title);
                }
            }
        }

        // Display's the title of all the operas
        public static void displayOperaTitles(ElementSet anElementSet)
        {
            Element currObject;
            Opera opera;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                if (currObject.getClassName().Equals("Opera"))
                {
                    opera = (Opera)currObject; // casts the currentObject as Movie Object
                                               // so that the title can be accessed
                    Console.WriteLine(opera.Title);
                }
            }
        }

        // Display's the information for a specified movie
        public static void displayMovie(ElementSet anElementSet, string title)
        {
            bool found = false;

            Element currObject;
            Movie movie;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                if (currObject.getClassName().Equals("Movie"))
                {
                    movie = (Movie)currObject;
                    if (movie.Title.Equals(title))
                    {
                        movie.display();
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("There is no Movie with that title.");
            }
        }

        // Display's the information for a specified opera
        public static void displayOpera(ElementSet anElementSet, string title)
        {
            bool found = false;

            Element currObject;
            Opera opera;

            Console.WriteLine("\n");
            for (int i = 0; i < anElementSet.size(); i++)
            {
                currObject = anElementSet.getCurrent();
                if (currObject.getClassName().Equals("Opera"))
                {
                    opera = (Opera)currObject;
                    if (opera.Title.Equals(title))
                    {
                        opera.display();
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("There is no Movie with that title.");
            }
        }

        // Display's the titles for all movies released in a specified year
        public static void displayYear(Movie[] movies, int year)
        {
            Console.WriteLine("\n");
            foreach (Movie movie in movies)
            {
                if (movie.Year == year)
                {
                    Console.WriteLine(movie.Year);
                }
                else
                {
                    Console.WriteLine("No movies exist for that year.");
                }
            }
        }

        // Display's the titles for all the movies an actor is in
        public static void displayStar(Movie[] movies, string star)
        {
            bool starredInSomething = false;

            Console.WriteLine("\n");
            foreach (Movie movie in movies)
            {
                if (movie.hasStar(star))
                {
                    starredInSomething = true;
                    Console.WriteLine(movie.Title);
                }
            }

            if(!starredInSomething)
            {
                Console.WriteLine("\nThe star wasn't found in any movie.");
            }
        }

        // adds a Movie to the set
        public static void addMovie(ElementSet anElementSet)
        {
            Element movie = new Movie();
            movie.readIn();
            int result = anElementSet.add(movie);

            // feedback on the result of the add
            if (result == 0)
            {
                Console.WriteLine("\nThe set is full.");
            }
            else if (result == -1)
            {
                Console.WriteLine("\nThat Movie is already in the set.");
            }
            else
            {
                Console.WriteLine("\nSuccessful add.");
            }
        }

        // adds an Opera to the set
        public static void addOpera(ElementSet anElementSet)
        {
            Element opera = new Opera();
            opera.readIn();
            int result = anElementSet.add(opera);

            // feedback on the result of the add
            if (result == 0)
            {
                Console.WriteLine("\nThe set is full.");
            }
            else if (result == -1)
            {
                Console.WriteLine("\nThat Opera is already in the set.");
            }
            else
            {
                Console.WriteLine("\nSuccessful add.");
            }
        }
    }
}
