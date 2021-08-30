using System;

namespace features
{
    static class ExtentionString
    {
        public static string uppercaseFirstLetter(this string value)
        {
            if(value.Length>0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }

    }
    class ExtensionMethodEx
    {
        static void Main(string[] args)
        {
            //string es = new string("hello");
            string es = "arun";
            Console.WriteLine(es.uppercaseFirstLetter());
        }
    }
}
