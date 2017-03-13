using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS02
{
    class ElementSet
    {
        // Data Fields
        private Element[] theList;
        private int currentIndex;
        private int currentSize;
        private const int MAXSETSIZE = 100;

        // Constructor
        public ElementSet()
        {
            theList = new Element[MAXSETSIZE];
            currentIndex = -1;
            currentSize = 0;
        }

        // Tests to see if passed Element is in the set
        public bool isMemberOf(Element anElement)
        {
            string paramClass = anElement.getClassName();
            string currClass;

            for (int i = 0; i < currentSize; i++)
            {
                currClass = theList[i].getClassName();

                if (currClass.Equals(paramClass))
                {
                    if (theList[i].equals(anElement))
                    {
                        return true;
                    }
                }
            }

            // not found
            return false;
        }

        // tests to see if theList is full
        public bool isFull()
        {
            return currentSize == MAXSETSIZE;
        }

        // Tests to see if theList is empty
        public bool isEmpty()
        {
            return currentSize == 0;
        }

        // Returns the current size of theList
        public int size()
        {
            return currentSize;
        }

        // Returns the current element
        public Element getCurrent()
        {
            int saveIndex = currentIndex;

            if (currentIndex == currentSize - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            return theList[saveIndex].clone();
        }

        // Adds an Element to theList
        public int add(Element anElement)
        {
            if (currentSize == MAXSETSIZE)
            {
                return 0; // set is full
            }
            else if (this.isMemberOf(anElement))
            {
                return -1; // already in the set
            }

            // add to set
            theList[currentSize] = anElement.clone();

            // increment currentSize
            currentSize++;

            // set currentIndex to added Element if it is the first in the set
            if (currentSize == 1)
            {
                currentIndex = 0;
            }

            return 1; // success
        }

        // clears the entire set back to empty
        public void clear()
        {
            // clear up memory while in use
            for (int i = 0; i < currentSize; i++)
            {
                theList[i] = null;
            }

            // reset currentIndex and currentSize
            currentIndex = -1;
            currentSize = 0;
        }

        public void display()
        {
            if (currentSize == 0)
            {
                Console.WriteLine("There are no objects in the set.");
            }
            else
            {
                Console.WriteLine("Here are the Objects in the set: \n");
                for (int i = 0; i < currentSize; i++)
                {
                    theList[i].display();
                    Console.WriteLine("\n");
                }
            }
        }

        // Removes a specified object from theList
        public bool removeAnObject(Element anObject)
        {
            string paramClass = anObject.getClassName();
            string currClass;

            for (int i = 0; i < currentSize; i++)
            {
                currClass = theList[i].getClassName();
                if (currClass.Equals(paramClass))
                {
                    if(theList[i].equals(anObject))
                    {
                        theList[i] = null;

                        if (currentIndex == i)
                        {
                            currentIndex--;
                        }

                        return true; // success
                    }
                }
            }

            return false; // not found in set
        }

        // replaces a specified object from theList with an user edited replacement
        public bool editAnObject(Element editedObject)
        {
            string paramClass = editedObject.getClassName();
            string currClass;

            for (int i = 0; i < currentSize; i++)
            {
                currClass = theList[i].getClassName();
                if (currClass.Equals(paramClass))
                {
                    if (theList[i].equals(editedObject))
                    {
                        theList[i] = editedObject.clone();
                        return true; // success
                    }
                }
            }

            return false; // not found in set
        }
    }
}
