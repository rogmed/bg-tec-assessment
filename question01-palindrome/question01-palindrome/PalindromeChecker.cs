public class PalindromeChecker
{
    public bool IsPalindrome(string input)
    {
        // Remove non-alphanumeric characters and convert to lowercase
        var cleanedInput = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        // Check if the cleaned input is equal to its reverse
        return cleanedInput == new string(cleanedInput.Reverse().ToArray());
    }
}
