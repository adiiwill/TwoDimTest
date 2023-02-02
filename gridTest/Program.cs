namespace gridTest
{
    internal class Program
    {
        static void Print(tdArray array)
        {
            for (int i = 0; i < array.a; i++)
            {
                for (int j = 0; j < array.b; j++)
                {
                    Console.Write($"{array.arrayOfNumbers[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // Generates the array as "test"
            tdArray test = new tdArray(5, 5);

            Console.WriteLine("TEST DEMO\n");
            Console.WriteLine("===================================");

            //Prints out the array (not included in the class)
            Print(test);

            Console.WriteLine("===================================");

            // Inputs a number into the "number" variable
            Console.Write("\nInsert a number from the list: ");
            int number = Convert.ToInt32(Console.ReadLine());

            // Checks if the inputted number is in the array
            if (number > 0 && number <= test.Len)
            {
                // The "nb" array will store the tdArray's neighbors. (check the Neighbor's function for more info)
                int[] nb = test.Neighbors(number);

                // Will write out the specified number's neighbors (0s are out of index indicators)
                Console.WriteLine("\nIt's neighbors:");
                Console.WriteLine($"\t{nb[0]}\t{nb[1]}\t{nb[2]}");
                Console.WriteLine($"\t{nb[3]}\tN\t{nb[4]}");
                Console.WriteLine($"\t{nb[5]}\t{nb[6]}\t{nb[7]}");

                // Will display the number's coordinates
                Console.WriteLine($"x:{test.Find(number)[1] + 1} y:{test.Find(number)[0] + 1}");

                // Will display the total size of the array
                Console.WriteLine($"Size: {test.Len}");
            }
            else
            {
                Console.WriteLine("The specified number is not in the array!");
            }
        }
    }
}