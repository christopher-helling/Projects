using System;

namespace MathProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double sqrtToFind = 17; // find square root of 2
            double tolerance = Math.Pow(10, -6); // 10^-6 -- accurate to six decimal places
            double currentIteration = 0;
            double maxIterations = 1000;
            double currentGuess = sqrtToFind / 2; // initialize x_0 as half the number


            while (Math.Abs(func(currentGuess, sqrtToFind)) > tolerance) // compare the error to the given tolerance
            {
                currentIteration++; // use counter to prevent getting stuck in endless loop if nonconvergent
                currentGuess = currentGuess - func(currentGuess, sqrtToFind) / (2 * currentGuess); // x_(n+1) = x_n - f(x_n) / f'(x_n)

                if (currentIteration == maxIterations)
                {
                    Console.WriteLine("Maximum number of iterations reached.");
                    break;
                }
            }

            Console.WriteLine("The square root of " + sqrtToFind + " is approximately " + currentGuess);
            Console.ReadLine();
        }


        static double func(double x, double sqrtToFind)
        {
            return Math.Pow(x, 2) - sqrtToFind;
        }
    }
}
