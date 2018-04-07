using System;
using System.Collections.Generic;
namespace CatKeeper.Model
{

    public class CatsByGender
    {
        public IList<Cat> Cats { get; }

        public CatsByGender(IList<Cat> cats)
        {
            Cats = cats;
        }
    }

    public class Cat
    {
        public string Gender { get; }
        public IList<string> Cats { get; }

        public Cat(string gender, IList<string> cats)
        {
          
            Gender = gender;
            Cats = cats;
        }
    }

}
