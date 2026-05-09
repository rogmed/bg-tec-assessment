public class PalindromeChecker
{
    public bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        var cleanedInput = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        return cleanedInput == new string(cleanedInput.Reverse().ToArray());
    }
}
