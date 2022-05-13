using System;
using NUnit.Framework;

namespace Digbyswift.Extensions.Test
{
    public class StringExtensionTests
    {
        
        #region MaskRight

        [Test]
        public void MaskRight_Throws_WhenInputIsNull()
        {
            const string testInput = null;

            Assert.Throws<ArgumentNullException>(() => testInput.MaskRight(0));
        }

        [Test]
        public void MaskRight_Throws_WhenNumberOfVisibleCharactersIsLessThanZero()
        {
            const string testInput = "hello";
            const int numberOfVisibleCharacters = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => testInput.MaskRight(numberOfVisibleCharacters));
        }

        [Test]
        public void MaskRight_Throws_WhenNumberOfVisibleCharactersIsGreaterThanLengthOfInput()
        {
            const string testInput = "hello";
            const int numberOfVisibleCharacters = 6;

            Assert.Throws<ArgumentOutOfRangeException>(() => testInput.MaskRight(numberOfVisibleCharacters));
        }

        [TestCase(0, "*****")]
        [TestCase(1, "h****")]
        [TestCase(2, "he***")]
        [TestCase(3, "hel**")]
        [TestCase(4, "hell*")]
        [TestCase(5, "hello")]
        public void MaskRight_ReturnsMaskedInput_WhenNumberOfVisibleCharactersIsLessThanLengthOfInput(int numberOfVisibleCharacters, string expectedOutput)
        {
            // Arrange
            const string testInput = "hello";

            // Act
            var output = testInput.MaskRight(numberOfVisibleCharacters);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        #endregion

        #region MaskLeft

        [Test]
        public void MaskLeft_Throws_WhenInputIsNull()
        {
            const string testInput = (string)null;

            Assert.Throws<ArgumentNullException>(() => testInput.MaskLeft(0));
        }

        [Test]
        public void MaskLeft_Throws_WhenNumberOfVisibleCharactersIsLessThanZero()
        {
            const string testInput = "hello";
            const int numberOfVisibleCharacters = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => testInput.MaskLeft(numberOfVisibleCharacters));
        }

        [Test]
        public void MaskLeft_Throws_WhenNumberOfVisibleCharactersIsGreaterThanLengthOfInput()
        {
            const string testInput = "hello";
            const int numberOfVisibleCharacters = 6;

            Assert.Throws<ArgumentOutOfRangeException>(() => testInput.MaskLeft(numberOfVisibleCharacters));
        }

        [TestCase("")]
        [TestCase("    ")]
        public void MaskLeft_ReturnsEmptyString_WhenInputIsEmpty(string testInput)
        {
            // Act
            var output = testInput.MaskLeft(0);

            Assert.That(output, Is.Empty);
        }

        [TestCase(0, "*****")]
        [TestCase(1, "****o")]
        [TestCase(2, "***lo")]
        [TestCase(3, "**llo")]
        [TestCase(4, "*ello")]
        [TestCase(5, "hello")]
        public void MaskLeft_ReturnsMaskedInput_WhenNumberOfVisibleCharactersIsLessThanLengthOfInput(int numberOfVisibleCharacters, string expectedOutput)
        {
            // Arrange
            const string testInput = "hello";

            // Act
            var output = testInput.MaskLeft(numberOfVisibleCharacters);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        #endregion

    }
}