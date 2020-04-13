using System;

namespace PrimeDetector
{
    public class PrimeDetectorModel
    {
        public PositiveDetector positiveDetector { get; set; }

        public PrimeDetectorModel(PositiveDetector positiveDetector)
        {
            this.positiveDetector = positiveDetector;
        }

        public bool IsPrime(int n)
        {
            if (!positiveDetector.IsNumberPositive(n)) throw new Exception("Invalid Input");

            var isPrime = true;

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) isPrime = false;
            }

            return isPrime;
        }

        public bool HasPrimeId(PersonModel person)
        {
            return IsPrime(person.Id);
        }
    }

}

