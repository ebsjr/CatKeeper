namespace CatKeeper.Tests
{
    using Xunit;
    using Cats;
    using System.Collections.Generic;
    using Cats.Model;
    using Newtonsoft.Json;

    public class GetCatByOwnersGenderTests
    {
       

        [Fact]
        public void GetCatsGroupByOwnersGender_Test()
        {
            Processor processor = new Processor();

            var json = @"[{""name"":""Bob"",""gender"":""Male"",""age"":23,""pets"":[{""name"":""Garfield"",""type"":""Cat""},{""name"":""Fido"",""type"":""Dog""}]},{""name"":""Jennifer"",""gender"":""Female"",""age"":18,""pets"":[{""name"":""Garfield"",""type"":""Cat""}]},{""name"":""Steve"",""gender"":""Male"",""age"":45,""pets"":null},{""name"":""Fred"",""gender"":""Male"",""age"":40,""pets"":[{""name"":""Tom"",""type"":""Cat""},{""name"":""Max"",""type"":""Cat""},{""name"":""Sam"",""type"":""Dog""},{""name"":""Jim"",""type"":""Cat""}]},{""name"":""Samantha"",""gender"":""Female"",""age"":40,""pets"":[{""name"":""Tabby"",""type"":""Cat""}]},{""name"":""Alice"",""gender"":""Female"",""age"":64,""pets"":[{""name"":""Simba"",""type"":""Cat""},{""name"":""Nemo"",""type"":""Fish""}]}]";

            var owners = JsonConvert.DeserializeObject<IList<Owner>>(json);

            var catsByGender = processor.GetCatsGroupByOwnersGender(owners);

            // ---------------------------
            // This should be the result
            // ---------------------------
            // Female
            // - Garfield
            // - Simba
            // - Tabby

            // Male
            // - Garfield
            // - Jim
            // - Max
            // - Tom 
            // --------------------------

            // check that result is not empty
            Assert.NotNull(catsByGender);

            // check that it has 2 items
            Assert.Equal(2, catsByGender.Cats.Count);

            // check genders in ascending order
            Assert.Equal("Female", catsByGender.Cats[0].Gender);
            Assert.Equal("Male", catsByGender.Cats[1].Gender);

            // check that each gender has correct number of cats
            Assert.Equal(3, catsByGender.Cats[0].Cats.Count);
            Assert.Equal(4, catsByGender.Cats[1].Cats.Count);

            // check that Female's cats are in ascending order
            Assert.Equal("Garfield", catsByGender.Cats[0].Cats[0]);
            Assert.Equal("Simba", catsByGender.Cats[0].Cats[1]);
            Assert.Equal("Tabby", catsByGender.Cats[0].Cats[2]);

            // check that Male's cats are in ascending order
            Assert.Equal("Garfield", catsByGender.Cats[1].Cats[0]);
            Assert.Equal("Jim", catsByGender.Cats[1].Cats[1]);
            Assert.Equal("Max", catsByGender.Cats[1].Cats[2]);
            Assert.Equal("Tom", catsByGender.Cats[1].Cats[3]);

        }


        [Fact]
        public void GetOwners_Test()
        {
            DataAccess dataAccess = new DataAccess();

            var owners = dataAccess.GetOwners();

            // check that result is not empty
            Assert.NotNull(owners);

            // check that it has 6 items
            Assert.Equal(6, owners.Count);

        }
    }
}
