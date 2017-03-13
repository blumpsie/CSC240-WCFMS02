using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSC240_WCFMS02
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0; // to keep track of the number of movies

            // Create a temporary array that has a pretty big length
            Movie[] tempMovies = new Movie[50];

            // initialize each of the objects in tempMovies
            for(int i = 0; i < 50; i++)
            {
                tempMovies[i] = new Movie();
            }

            // Read in at least one Movie
            tempMovies[count].readIn();
            count++;

            // prompt the user to see if they want to enter another Movie
            Console.WriteLine("\nWould you like to eneter another movie (yes/no)?");
            string anotherMovie = Console.ReadLine().ToUpper();

            // check to see if the user input is valid
            while(!anotherMovie[0].Equals('Y') && !anotherMovie[0].Equals('N'))
            {
                Console.WriteLine("\nInvalid Input. \nPlease try again (yes/no)?");
                anotherMovie = Console.ReadLine().ToUpper();
            }

            // Loop through the reading of movies as long as the 
            //user wants to keep entering them
            while(anotherMovie[0] == 'Y')
            {
                tempMovies[count].readIn();
                count++;

                Console.WriteLine("\nWould you like to eneter another movie (yes/no)?");
                anotherMovie = Console.ReadLine().ToUpper();
            }

            // Create a new array with the a set size and fill it with the movies
            Movie[] theMovies = new Movie[count];
            for(int i = 0; i < theMovies.Length; i++)
            {
                theMovies[i] = tempMovies[i];
            }

            // Sort the array of Movie objects
            bubbleSort(theMovies);

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
                                 + "1 - Display the titles of all the movies\n"
                                 + "2 - Display the data for a specific movie\n"
                                 + "3 - Display the titles of all the movies released in a given year\n"
                                 + "4 - Display the titles of all the movies with a particular star\n"
                                 + "5 - Quit the program\n");
                    userChoice = Console.ReadLine();

                    if (userChoice[0] != '1' ||
                        userChoice[0] != '2' ||
                        userChoice[0] != '3' ||
                        userChoice[0] != '4' ||
                        userChoice[0] != '5')
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
                        displayTitles(theMovies);
                        break;
                    case '2':
                        Console.WriteLine("\nWhat movie would you like to search for?");
                        String title = Console.ReadLine();
                        displayMovie(theMovies, title);
                        break;
                    case '3':
                        Console.WriteLine("\nWhat year would you like to see the movies of?");
                        int year = Convert.ToInt32(Console.ReadLine());
                        displayYear(theMovies, year);
                        break;
                    case '4':
                        Console.WriteLine("What star would you like to search for?");
                        string star = Console.ReadLine();
                        displayStar(theMovies, star);
                        break;
                    case '5':
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
                    if (String.Compare(movies[i].getTitle(), movies[i + 1].getTitle(), true) > 0)
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
        public static void displayTitles(Movie[] movies)
        {
            Console.WriteLine("\n");
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.getTitle());
            }
        }

        // Display's the information for a specified movie
        public static void displayMovie(Movie[] movies, string title)
        {
            bool found = false;
            int min = 0;
            int max = movies.Length - 1;
            int mid = 0;

            while (!found)
            {
                if (max <= min)
                {
                    Console.WriteLine("\nThat movie does not exist.");
                    found = true;
                }

                mid = min + (max - min) / 2;

                if (String.Compare(movies[mid].getTitle(), title, true) < 0)
                {
                    min = mid + 1;
                }
                else if (String.Compare(movies[mid].getTitle(), title, true) > 0)
                {
                    min = mid - 1;
                }
                else if (String.Compare(movies[mid].getTitle(), title, true) == 0)
                {
                    movies[mid].display();
                    found = true;
                }
            }
        }

        // Display's the titles for all movies released in a specified year
        public static void displayYear(Movie[] movies, int year)
        {
            Console.WriteLine("\n");
            foreach (Movie movie in movies)
            {
                if (movie.getYear() == year)
                {
                    Console.WriteLine(movie.getTitle());
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
                    Console.WriteLine(movie.getTitle());
                }
            }

            if(!starredInSomething)
            {
                Console.WriteLine("\nThe star wasn't found in any movie.");
            }
        }
    }

}
