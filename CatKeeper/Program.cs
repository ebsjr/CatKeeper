namespace Cats
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            // access data source
            DataAccess dataAccess = new DataAccess();
            Processor processor = new Processor();

            var owners = dataAccess.GetOwners();

            // load source to CatsByGender object 
            var CatsByGender = processor.GetCatsGroupByOwnersGender(owners);

            // print  result to console
            foreach (var gender in CatsByGender.Cats)
            {
                Console.WriteLine("==========");
                Console.WriteLine(gender.Gender);
                Console.WriteLine("==========");

                var cats = gender.Cats;

                foreach (var cat in cats)
                {
                    Console.WriteLine(cat);
                }

                Console.WriteLine();

            }


        }
    }
}
