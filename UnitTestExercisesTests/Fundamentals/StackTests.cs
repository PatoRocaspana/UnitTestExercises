using System;
using TestNinja.Fundamentals;
using Xunit;

namespace UnitTestExercisesTests.Fundamentals
{
    public class StackTests
    {
        private readonly Stack<string> _stack;

        public StackTests()
        {
            _stack = new Stack<string>();
        }

        [Fact]
        public void Count_ReturnZero_WhenIsEmpty()
        {
            //Act
            var result = _stack.Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Push_ThrowsArgumentNullException_WhenArgumentIsNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => _stack.Push(null));
        }

        [Fact]
        public void Push_AddObjToStack_WhenArgumentIsNotNull()
        {
            //Arrange
            var input = "a";

            //Act
            _stack.Push(input);

            //Assert
            Assert.Equal(1, _stack.Count);
        }

        [Fact]
        public void Pop_ThrowInvalidOperationException_StackIsEmpty()
        {
            //Arrange
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Fact]
        public void Pop_ReturnLastItem_WhenNoEmptyStack()
        {
            // Arrange 
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            var result = _stack.Pop();

            // Assert
            Assert.Equal("c", result);
        }

        [Fact]
        public void Pop_RemoveLastItem_WhenNoEmptyStack()
        {
            // Arrange 
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            _stack.Pop();

            // Assert
            Assert.Equal(2, _stack.Count);
        }

        [Fact]
        public void Peek_ThrowInvalidOperationException_StackIsEmpty()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Fact]
        public void Peek_ReturnLastItem_WhenNoEmptyStack()
        {
            // Arrange 
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            var result = _stack.Peek();

            // Assert
            Assert.Equal("c", result);
        }

        [Fact]
        public void Peek_DoesntRemoveAnyObjectOnTheStack_WhenNoEmptyStack()
        {
            // Arrange 
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            // Act
            _stack.Peek();

            // Assert
            Assert.Equal(3, _stack.Count);
        }
    }
}
