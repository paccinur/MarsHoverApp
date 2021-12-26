using NUnit.Framework;
using MarsHoverApp.Extensions;
using System;

namespace MarsHoverApp.Test
{
    [TestFixture]
    public class MarsHoverConsoleAppTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckAndCreateField_MissingInput_ThrowsError()
        {
            string[] inputs = { "1" };
            Assert.Throws<InvalidArgumentException> (()=> ProgramExtensions.CheckAndCreateField(inputs));
        }
        [Test]
        public void CheckAndCreateField_InvalidFormatInput_ThrowsError()
        {
            string[] inputs = { "A", "2" };
            Assert.Throws<InvalidArgumentException> (()=> ProgramExtensions.CheckAndCreateField(inputs));
        }
        [Test]
        public void CheckAndCreateField_RightInput_CreatesField()
        {
            string[] inputs = { "1", "2" };
            Assert.IsNotNull(ProgramExtensions.CheckAndCreateField(inputs));
        }
        [Test]
        public void CheckAndCreateHover_MissingInput_ThrowsError()
        {
            Field field = new Field(1, 1);
            string[] inputs = { "1", "2" };
            Assert.Throws<InvalidArgumentException>(() => ProgramExtensions.CheckAndCreateHover(inputs,field));
        }
        [Test]
        public void CheckAndCreateHover_WrongFormatInput_ThrowsError()
        {
            Field field = new Field(1, 1);
            string[] inputs = { "1", "B", "1" };
            Assert.Throws<InvalidArgumentException>(() => ProgramExtensions.CheckAndCreateHover(inputs, field));
        }
        [Test]
        public void CheckAndCreateHover_CreateOnTopOfExistingHover_ThrowsError()
        {
            Field field = new Field(5, 5);
            field.AddHover(new Hover(1,1,Alignment.N));
            string[] inputs = { "1", "1", "N" };
            Assert.Throws<ClashException>(() => ProgramExtensions.CheckAndCreateHover(inputs, field));
        }
        [Test]
        public void CheckAndCreateHover_RightInput_CreatesHover()
        {
            Field field = new Field(5, 5);
            string[] inputs = { "1", "2", "N" };
            var hover = ProgramExtensions.CheckAndCreateHover(inputs, field);
            Assert.IsNotNull(hover);
        }
        [Test]
        public void CheckMovementInput_WrongInputFormat_ThrowsException()
        {
            string input = "MLMLMLMLRA";
            Assert.Throws<InvalidArgumentException>(() => ProgramExtensions.CheckMovementInput(input));
        }
        [Test]
        public void CheckMovementInput_MissingInput_ThrowsException()
        {
            string input = "";
            Assert.Throws<InvalidArgumentException>(() => ProgramExtensions.CheckMovementInput(input));
        }
        [Test]
        public void CheckMovementInput_RightInput_DoesNothing()
        {
            string input = "MLMLMLMLR";
            ProgramExtensions.CheckMovementInput(input);
            Assert.IsTrue(true);
        }
    }
}