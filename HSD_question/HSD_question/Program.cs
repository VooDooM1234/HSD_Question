using System;

/*  NOTES::
 *  steps:
 *  1. first find where input is located in spiral matrix.
 *  2. then find manahattan distance from its location to centre.
 *  
    Observations:
        1. Postion of input in matrix will always have a distance bewteen the middle point and corner of matrix.
        2. Bottom right corner will always be a perfect square relating to the layer it is confined in. Thus the sqrt of an input will equal the layer it is contained in 
        rounded up. - possibly mean that the number of indexs for that layer as a percentage may find location of input in that layer?? 
        

 *  Manhattan distance = 
 *      "In a plane with p1 at (x1, y1) and p2 at (x2, y2), it is |x1 - x2| + |y1 - y2|"
 *
 *  Altenerative Manhattan distance calculator for spiral matrix:
 *      For n > 1, a(n) = layer(n) + abs(((n-1) mod (2*layer(n)) - layer(n))) (conjectured) where layer(n) = ceiling(0.5*sqrt(n) - 0.5)
    Reference: http://oeis.org/A214526
 * 

 */

namespace HSD_question
{
    class Program
    {
        static void Main(string[] args)
        {
            // matrix co-ord
           int val = 289326;
           //int val = 25;
            
            //Calcualte number of rings in spiral in order to determine basic distance from the centre to location of input val. This essential gives on of the two coords for the location of number.
            // Sqrt of any number in ring rounded up = the ring number, with bottom right number of each ring being the perfect square of each ring.


            int n_ring = (int)Math.Ceiling((Math.Sqrt(val)-1)/2); // -1 so ring count doesnt included centre point as a ring.
                                                                  // without -1 it would give the centre point index of ring.

            int n_of_indexs_in_row = (int)Math.Ceiling((Math.Sqrt(val)));

            Console.WriteLine("Number of Rings = {0}", n_ring);
            Console.WriteLine("Number of Elements in floor of matrix = {0}", n_of_indexs_in_row);

            //centre of matrix row
            int x1 = (int)Math.Ceiling((double)(n_of_indexs_in_row + 1) / 2);

           Console.WriteLine("Centre of Matrix = {0}", x1);

            //@ bottom right corner - this will give the max distance from the ring to the centre but not the actual location of the input vals index to centre.
            int x2 = (n_of_indexs_in_row * n_of_indexs_in_row);
            //distance between input val and known squared corner of ring.
            x2 = x2 - val;

            //Console.WriteLine("Distance between centre and val= {0}", x2);
            Console.WriteLine("");
           
            /*This formula only works on on axis (x) in the case its wrttien here, 
            which is why in tests cases it was correct for input on horizontal index in matrix but not for vertical

            Soultion One attempted to find distance by calculating the distance between the know corner perfect sqaure number and the input val in order to determine 
            its location in its respective ring (x2). Then using the Manahttan formula to calulate distance from that index to centre of Matrix (x1).

            This attempt didnt work - I beleieve i may have messed the maths up somewhere - theres a looping +/- 1 that should be somewhere, as the number calculated + (n_rings +/- 1) gives answer.
            */

            int manhattanSolutionOne = Math.Abs(x1 - x2);

            /*
             * Soultion two used the Manhattan formula specfically for spiral matrix as referecened - This was succuessful.
             * 
             *    ANSWER = 419
             */

            //FORMULA: https://imgur.com/x6itOEf
            int manhattanSolutionTwo = n_ring + Math.Abs(((val-1) % (2*n_ring))-n_ring); 
         
            Console.WriteLine("Manhattan Distance Solution One = {0}", manhattanSolutionOne); 
            Console.WriteLine("Manhattan Distance Solution Two = {0}" , manhattanSolutionTwo);

        }
    }
}
