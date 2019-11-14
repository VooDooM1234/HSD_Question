using System;

/*  NOTES::
 *  
 *  first find where input is located in spiral matrix.
 *  then find manahattan distance from its location to centre.
 *  
 *  Manhattan distance = 
 *      "In a plane with p1 at (x1, y1) and p2 at (x2, y2), it is |x1 - x2| + |y1 - y2|"
 * 
 * 
 * postion of input in matrix will always have a distance bewteen the middle point and corner of matrix
 * 
 * 
 * 
 * 
 * 
 */

namespace HSD_question
{
    class Program
    {
        static void Main(string[] args)
        {
            // matrix coord
            int val = 289326;
            
            //Calcualte number of rings in spiral in order to determine basic distance from the centre to location of input val. This essential gives on of the two coords for the location of number.
            // Sqrt of any number in ring rounded up = the ring number, with bottom right number of each ring being the perfect square of each ring.

            int n_ring = (int)Math.Ceiling((Math.Sqrt(val)-1)/2);

            Console.WriteLine("Number of Rings = {0}", n_ring);

            //centre of matrix
            int x1 = (int)Math.Ceiling((double)n_ring +1 / 2);
            int y1 = (int)Math.Ceiling((double)n_ring +1 / 2);

            Console.WriteLine("Centre of Matrix = {0} , {1}", x1, y1);

            //@ bottom right corner
            int x2 = (n_ring ^2);
            int y2 = (n_ring ^2);


            //This formulea only works on on axis (x) in the case its wrttien here, 
            //which is why in tests cases it was correct for input on horizontal index in matrix but not for vertical

            //int manhattan = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

            //FORMULEA: https://imgur.com/x6itOEf
            int manhattan = n_ring + Math.Abs(((val-1) % (2*n_ring))-n_ring); 
         
            Console.WriteLine("manhattan distance = {0}", manhattan);

         

        }
    }
}
