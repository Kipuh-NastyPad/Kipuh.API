namespace Kipuh.API.Kipuh.Shared.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string? text)
    {
        static IEnumerable<char> Convert(IEnumerator<char> letterEnumerator)
        {
            // Validation for ensuring database tables were created.
            if(!letterEnumerator.MoveNext())
                yield break;

            yield return char.ToLower(letterEnumerator.Current);
            while (letterEnumerator.MoveNext())
            {
                if (char.IsUpper(letterEnumerator.Current))
                    yield return '_';
                yield return char.ToLower(letterEnumerator.Current);
            }
        }
        return new string(Convert(text!.GetEnumerator()).ToArray());
    }

    public static string ToFirstLetterLower(this string text)
    {
        string firstLetter = Char.ToLower(text[0]).ToString();
        string subString = text.Substring(1);
        return firstLetter + subString;
    }
    public static string Capitalize(this string text)
    {
        string firstLetter = Char.ToUpper(text[0]).ToString();
        string subString = text.Substring(1).ToLower();
        return firstLetter + subString;
    }
}