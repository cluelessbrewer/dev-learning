public class Palindrome
{
    public static bool IsPalindrome(string word)
    {
        return (Reverse(word.ToLower()) == word.ToLower());
    }
    
    public static string Reverse( string s )
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse( charArray );
        return new string( charArray );
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(Palindrome.IsPalindrome("Deleveled"));
    }
}