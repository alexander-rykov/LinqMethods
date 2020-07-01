using System.Collections;
using NUnit.Framework;

namespace LinqMethods.Tests
{
    [TestFixture]
    public class Class1Tests
    {
        [Test]
        public void GetFruits_ReturnsValidDate()
        {
            var c = new Class1();
            var result = c.GetFruits(new []
            {
                (true, "apple"), (false, "Moscow"), (true, "banana"), (false, "Kiev"), (true, "lemon"), (false, "Minsk")
            });

            Assert.Contains("apple", (ICollection)result);
            Assert.Contains("banana", (ICollection)result);
            Assert.Contains("lemon", (ICollection)result);
        }

        [Test]
        public void GetFruits_UsesLinq()
        {
            var c = new Class1();
            var expr = c.GetFruits2();

            var methodText = expr.ToString(); // == "k => k.Where(i => i.Item1).Select(i => i.Item2).ToArray()"
            bool hasSelectCall = methodText.Contains("Select");
            bool hasWhereCall = methodText.Contains("Where");

            Assert.IsTrue(hasSelectCall);
            Assert.IsTrue(hasWhereCall);

            var del = expr.Compile();
            var result = del(new[]
            {
                (true, "apple"), (false, "Moscow"), (true, "banana"), (false, "Kiev"), (true, "lemon"), (false, "Minsk")
            });

            Assert.Contains("apple", (ICollection)result);
            Assert.Contains("banana", (ICollection)result);
            Assert.Contains("lemon", (ICollection)result);
        }
    }
}
