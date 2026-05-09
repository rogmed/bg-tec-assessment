namespace PalindromeCheckerTest
{
    [TestClass]
    public sealed class PalindromeCheckerTest
    {
        [TestMethod]
        [DataRow("101")]
        [DataRow("222")]
        [DataRow("kook")]
        [DataRow("l")]
        [DataRow("infinitytinifni")]
        public void ShouldReturnTrueIfIsAPalindrome(string input)
        {
            var palindromeChecker = new PalindromeChecker();
            var result = palindromeChecker.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Deleveled")]
        [DataRow("deleveLED")]
        [DataRow("PanOceaniAinaeconap")]
        public void ShouldIgnoreCharacterCase(string input)
        {
            var palindromeChecker = new PalindromeChecker();
            var result = palindromeChecker.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("1%01")]
        [DataRow("2__22")]
        [DataRow("ko=ok")]
        [DataRow("l]]]")]
        [DataRow("ko  ok")]
        [DataRow("  kook")]
        public void ShouldIgnoreNonAlphanumericCharacters(string input)
        {
            var palindromeChecker = new PalindromeChecker();
            var result = palindromeChecker.IsPalindrome(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("root")]
        [DataRow("beet")]
        public void ShouldReturnFalseIfNonPalindrome(string input)
        {
            var palindromeChecker = new PalindromeChecker();
            var result = palindromeChecker.IsPalindrome(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void ShouldReturnFalseIfNullOrEmpty(string input)
        {
            var palindromeChecker = new PalindromeChecker();
            var result = palindromeChecker.IsPalindrome(input);
            Assert.IsFalse(result);
        }
    }
}
