namespace QuicksortTest
{
    [TestClass]
    public sealed class QuicksorterTest
    {
        [TestMethod]
        public void Sort_Null_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Quicksorter.Sort(null));
        }

        [TestMethod]
        public void Sort_EmptyArray_ReturnsEmpty()
        {
            double[] input = Array.Empty<double>();
            var sorted = Quicksorter.Sort(input);
            Assert.IsEmpty(sorted);
        }

        [TestMethod]
        public void Sort_SingleElement_ReturnsSame()
        {
            double[] input = new[] { 3.0 };
            var sorted = Quicksorter.Sort(input);
            CollectionAssert.AreEqual(new double[] { 3.0 }, sorted);
        }

        [TestMethod]
        public void Sort_Duplicates_ReturnsSorted()
        {
            double[] input = new[] { 5.0, 1.0, 3.0, 5.0, 2.0 };
            var expected = new[] { 1.0, 2.0, 3.0, 5.0, 5.0 };
            var sorted = Quicksorter.Sort(input);
            CollectionAssert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void Sort_IntegersAndFloats_ReturnsSorted()
        {
            double[] input = new[] { 2, 3.5, 1, 4.25, 3 };
            var expected = new[] { 1.0, 2.0, 3.0, 3.5, 4.25 };
            var sorted = Quicksorter.Sort(input);
            CollectionAssert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void Sort_AlreadySorted_RemainsSorted()
        {
            double[] input = new[] { 1.0, 2.0, 3.0, 4.0 };
            var sorted = Quicksorter.Sort(input);
            CollectionAssert.AreEqual(input, sorted);
        }

        [TestMethod]
        public void Sort_ReturnsNewArray_DoesNotModifyOriginal()
        {
            double[] input = new[] { 3.0, 1.0, 2.0 };
            var copy = (double[])input.Clone();
            var sorted = Quicksorter.Sort(input);
            // original should remain unchanged
            CollectionAssert.AreEqual(copy, input);
        }
    }
}
