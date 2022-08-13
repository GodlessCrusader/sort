using System;
using System.Collections.Generic;

namespace sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static IEnumerable<int> Sort(IEnumerable<int> stream, int sortFactor, int maxValue)
        {
            var buf = new int[sortFactor];
            var count = 0;
            while(stream.GetEnumerator().MoveNext())
                count++;
            var output = new int[count];
            count = 0;
            foreach (int i in stream)
            {
                var offset = 1;
                while(offset <= sortFactor)
                {
                    if(offset == sortFactor)
                    {
                        if (i > buf[sortFactor])
                        {
                            //here buff will shift first num
                            buf[sortFactor] = i;
                        }
                        else
                        {
                            //in case this number is unique
                            output[count] = i;
                            count++;
                        }
                    }
                    else if (i > buf[sortFactor - offset])
                    {
                        //here buff will shift and write some numbers which are impossible to meet later in stream
                        buf[sortFactor - 1] = i;
                    }
                    else
                    {
                        offset++;
                    }
                }
                
            }
            
            
            return output;
        }
    }
}
