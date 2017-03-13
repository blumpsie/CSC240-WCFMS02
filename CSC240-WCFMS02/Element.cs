using System;
/*
 * Exactly the same as Element.java, hopefully they work exaclty the same too.
 */
namespace CSC240_WCFMS02
{
    abstract class Element
    {
        public string getClassName()
        {
            string resultStr;
            int whereAt;

            resultStr = this.ToString();
            whereAt = resultStr.IndexOf('@');
            resultStr = resultStr.Substring(0, whereAt);
            whereAt = resultStr.IndexOf('.');

            return resultStr.Substring(whereAt + 1);
        }

        public abstract void readIn();

        public abstract void display();

        public abstract bool equals(Element obj);

        public abstract Element clone();
    }
}
