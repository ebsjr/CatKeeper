namespace Cats
{
    using CatKeeper.Model;
    using Model;
    using System.Collections.Generic;
    using System.Linq;

    public class Processor
    {
        /// <summary>
        /// This method identifies all cats and group by owner's gender.
        /// The list of cats must in sort order ascending.
        /// </summary>
        /// <param name="Owners"></param>
        /// <returns></returns>
        /// 
        public CatsByGender GetCatsGroupByOwnersGender(IList<Owner> Owners)
        {

            var cats =
                (
                // loop thru owners and pets
                from owner in Owners
                where owner.pets != null && string.IsNullOrWhiteSpace(owner.gender) == false
                orderby owner.gender

                // get all pet where type is 'Cat'
                from pet in owner.pets
                where pet.type == "Cat"
                orderby pet.name ascending

                group pet by owner.gender into o

                select new Cat(gender: o.Key, cats: o.Select(c => c.name).ToList())

                ).ToList();

            var result = new CatsByGender(cats);

            return result;
        }
    }
}
