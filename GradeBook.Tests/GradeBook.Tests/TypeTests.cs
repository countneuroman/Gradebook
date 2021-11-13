using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }

        private static string ReturnMessage(string message)
        {
            return message;
        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            var name = "Vadim";
            var upper = MakeUpperCase(name);
            name = upper;

            Assert.Equal("VADIM", name);
        }

        private static string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private static void SetInt(object x)
        {
            x = 42;
        }

        private static object GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private static void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName("New Name");

            Assert.Equal("Book1", book1.Name);
        }

        private static void GetBookSetName(string name)
        {
            new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private static void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(ReferenceEquals(book1, book2));
        }

        private static InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
