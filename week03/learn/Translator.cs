public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));   // Output: Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Output: Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // Output: ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'.
    /// For example, in an English to German dictionary:
    /// myTranslator.AddWord("book", "buch").
    /// </summary>
    /// <param name="fromWord">The word to translate from.</param>
    /// <param name="toWord">The word to translate to.</param>
    public void AddWord(string fromWord, string toWord)
    {
        // If the word already exists, update its translation.
        if (_words.ContainsKey(fromWord))
        {
            _words[fromWord] = toWord;
        }
        else
        {
            _words.Add(fromWord, toWord);
        }
    }

    /// <summary>
    /// Translates the 'fromWord' into the word that this stores as the translation.
    /// </summary>
    /// <param name="fromWord">The word to translate.</param>
    /// <returns>The translated word or "???" if no translation is available.</returns>
    public string Translate(string fromWord)
    {
        // Check if the word exists in the dictionary and return the translation.
        if (_words.TryGetValue(fromWord, out var translatedWord))
        {
            return translatedWord;
        }

        // Return "???" if the word is not found.
        return "???";
    }
}
