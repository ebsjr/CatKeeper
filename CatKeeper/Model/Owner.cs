namespace Cats.Model
{
    using System.Collections.Generic;

    public class Owner
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }

    }
}
