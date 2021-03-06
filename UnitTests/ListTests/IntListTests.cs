using NUnit.Framework;
using JsonSrcGen;
using System.Collections.Generic;
using System;

[assembly: JsonList(typeof(int))] 

namespace UnitTests.ListTests
{
    public class IntListTests
    { 
        JsonSrcGen.JsonSrcGenConvert _convert;

        string ExpectedJson = "[-2147483648,-1,0,1,42,2147483647]";

        [SetUp]
        public void Setup()
        {
            _convert = new JsonSrcGenConvert();
        }

        [Test] 
        public void ToJson_CorrectString()
        {
            //arrange
            var list = new List<int>(){int.MinValue,-1,0, 1, 42, int.MaxValue};

            //act
            var json = _convert.ToJson(list);

            //assert
            Assert.That(json, Is.EqualTo(ExpectedJson));
        }

        [Test]
        public void ToJson_Null_CorrectString()
        {
            //arrange
            //act
            var json = _convert.ToJson((List<int>)null);

            //assert
            Assert.That(json, Is.EqualTo("null"));
        }

        [Test]
        public void FromJson_EmptyList_CorrectList()
        {
            //arrange
            var list = new List<int>();

            //act
            _convert.FromJson(list, ExpectedJson);

            //assert
            Assert.That(list.Count, Is.EqualTo(6));
            Assert.That(list[0], Is.EqualTo(int.MinValue));
            Assert.That(list[1], Is.EqualTo(-1));
            Assert.That(list[2], Is.EqualTo(0));
            Assert.That(list[3], Is.EqualTo(1));
            Assert.That(list[4], Is.EqualTo(42));
            Assert.That(list[5], Is.EqualTo(int.MaxValue));
        }

        [Test] 
        public void FromJson_PopulatedList_CorrectList()
        {
            //arrange
            var list = new List<int>(){1, 2, 3};

            //act
            list =_convert.FromJson(list, ExpectedJson);

            //assert
            Assert.That(list.Count, Is.EqualTo(6));
            Assert.That(list[0], Is.EqualTo(int.MinValue));
            Assert.That(list[1], Is.EqualTo(-1));
            Assert.That(list[2], Is.EqualTo(0));
            Assert.That(list[3], Is.EqualTo(1));
            Assert.That(list[4], Is.EqualTo(42));
            Assert.That(list[5], Is.EqualTo(int.MaxValue));
        }

        [Test] 
        public void FromJson_JsonNull_ReturnsNull()
        {
            //arrange
            var list = new List<int>(){1, 2, 3};

            //act
            list = _convert.FromJson(list, "null");

            //assert
            Assert.That(list, Is.Null);
        }

        [Test]
        public void FromJson_ListNull_MakesList()
        {
            //arrange
            //act
            var list = _convert.FromJson((List<int>)null, ExpectedJson);

            //assert
            Assert.That(list.Count, Is.EqualTo(6));
            Assert.That(list[0], Is.EqualTo(int.MinValue));
            Assert.That(list[1], Is.EqualTo(-1));
            Assert.That(list[2], Is.EqualTo(0));
            Assert.That(list[3], Is.EqualTo(1));
            Assert.That(list[4], Is.EqualTo(42));
            Assert.That(list[5], Is.EqualTo(int.MaxValue));
        }
    }
}