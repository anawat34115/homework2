using System;

class Program
{
    static void Main()
    {
        bool continueProcessing = true;

        while (continueProcessing)
        {
            Console.Write("Current half DNA sequence: ");
            string input = Console.ReadLine();

            if (IsValidSequence(input))
            {
                Console.WriteLine($"Current half DNA sequence: {input}");
                Console.Write("Do you want to replicate it? (Y/N): ");
                char confirmation = GetConfirmation();

                if (confirmation == 'Y')
                {
                    string replicatedSequence = ReplicateSequence(input);
                    Console.WriteLine($"Replicated half DNA sequence: {replicatedSequence}");
                }
                else if (confirmation == 'N')
                {
                    Console.WriteLine("DNA synthesis skipped.");
                }
            }
            else
            {
                Console.WriteLine("That half DNA sequence is invalid.");
            }

            Console.Write("Do you want to process another sequence? (Y/N): ");
            char restart = GetConfirmation();

            if (restart == 'N')
            {
                continueProcessing = false;
            }
        }
    }

    static bool IsValidSequence(string sequence)
    {
        foreach (char nucleotide in sequence)
        {
            if (nucleotide != 'A' && nucleotide != 'T' && nucleotide != 'C' && nucleotide != 'G')
            {
                return false;
            }
        }

        return true;
    }

    static string ReplicateSequence(string halfDNASequence)
    {
        string result = "";
        
        foreach (char nucleotide in halfDNASequence)
        {
            result += "TAGC"["ATCG".IndexOf(nucleotide)];
        }

        return result;
    }

    static char GetConfirmation()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input.Length == 1 && (input[0] == 'Y' || input[0] == 'N'))
            {
                return input[0];
            }
            else
            {
                Console.WriteLine("Please input Y or N.");
                Console.Write("Do you want to process another sequence? (Y/N): ");

            }
        }
    }
}
