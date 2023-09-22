
string[] wordlist = File.ReadAllLines("../../../ordlista.txt");
Console.WriteLine();



//string? input = string.Empty;
//int selected;

var r = new Random();
var randomLine = r.Next(0, wordlist.Length - 1);
var word = wordlist[randomLine];




var currentGuess = string.Empty;

while (currentGuess.Length < word.Length)
{
    currentGuess = currentGuess + "_";
}

var lives = 15;
var hasWon = false;



while (lives > 0 && !hasWon)
{
    Console.Clear();
    Console.WriteLine("A random word has been selected for you start guessing!");
    Console.WriteLine("Note: Swedish words with and without inflections");
    Console.WriteLine();
    Console.WriteLine(currentGuess);
    Console.WriteLine("current lives: " + lives);
    Console.Write("Please enter a letter as a guess: ");
    var guess = Console.ReadLine().ToLower();
    var guessWasRight = false;

    if (guess == word)
    {
        hasWon = true;
        Console.WriteLine("You have won!");
        // om gissningen är samma som ordet så har vi vunnit (ändra så att while loopen avbryts genom att "hasWon" ska bli true.
        // annars går vi ner till "else" och kör loopen för att hitta bokstäver
    }
    else
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (guess == word[i].ToString())
            {
                currentGuess = currentGuess.Remove(i, 1).Insert(i, guess);
                guessWasRight = true;
            }
        }
        if (!guessWasRight)
        {
            lives--;
            if (lives == 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You have lost!");
                Console.WriteLine("Right word was: " + word);

            }
        }
        if (currentGuess == word)
        {
            hasWon = true; // om vi har börjat fylla på med bokstäver men sen gissar hela ordet så ska loopen avbrytas genom hasWon blir true

            Console.WriteLine("You have won!");
        }
    }
}