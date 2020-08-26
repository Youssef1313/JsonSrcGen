using NUnit.Framework;
using JsonSG;


namespace UnitTests
{
    [Json]
    public class JsonClass
    {
        public string FirstName {get;set;}
        public string LastName {get;set;} 
    }

    public class StringPropertyTests
    {
        JsonSG.JsonSGConvert _convert;

        [SetUp]
        public void Setup()
        {
            _convert = new JsonSGConvert();
        }

        [Test]
        public void ToJson_CorrectString()
        {
            //arrange
            var jsonClass = new JsonClass()
            {
                FirstName = "Bob",
                LastName = "Marley"
            };

            //act
            var json = _convert.ToJson(jsonClass);

            //assert
            Assert.That(json, Is.EqualTo("{\"FirstName\":\"Bob\",\"LastName\":\"Marley\"}"));
        }


        [Test]
        public void FromJson_CorrectJsonClass()
        {
            //arrange
            var json = "{\"FirstName\":\"Bob\",\"LastName\":\"Marley\"}";
            var jsonClass = new JsonClass();

            //act
            _convert.FromJson(jsonClass, json);

            //assert
            Assert.That(jsonClass.FirstName, Is.EqualTo("Bob"));
            Assert.That(jsonClass.LastName, Is.EqualTo("Marley"));
        }
    }
}