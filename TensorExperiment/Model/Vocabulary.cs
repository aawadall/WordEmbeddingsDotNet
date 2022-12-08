namespace TensorExperiment.Model
{
    public class Vocabulary
    {
        private List<Token[]> _sentences;
        private Token[] _tokens;
        private Token[] _vocabulary;

        public Vocabulary(string fileName)
        {
            // Load data from file
            _sentences = ReadAndProcessSentences(fileName);
            _tokens = ReadAndPreprocessTextData(fileName).ToArray();
            _vocabulary = _tokens.Distinct().ToArray();

            // print some stats 
            Console.WriteLine("Vocabulary Object Created");
            Console.WriteLine($"Number of sentences: {_sentences.Count}");
            Console.WriteLine($"Number of tokens: {_tokens.Length}");
            Console.WriteLine($"Number of unique tokens: {_vocabulary.Length}");
        }

        private static List<Token[]>? ReadAndProcessSentences(string fileName)
        {
            // Read the text data 
            var lines = File.ReadAllLines(fileName);

            var sentences = new List<Token[]>();
            
            throw new NotImplementedException();
        }

        // one hot encoding 
        public short[] GetOneHotEncoding(string tokenName)
        {
            // create array of all zeros short 
            var oneHotEncoding = new short[_vocabulary.Length];

            // find the index of the token in the vocabulary
            var index = Array.FindIndex(_vocabulary, token => token.Text == tokenName);

            // set the index to 1
            oneHotEncoding[index] = 1;

            return oneHotEncoding;
        }

        private static IEnumerable<Token> ReadAndPreprocessTextData(string filename)
        {
            // Read the text data 
            var lines = File.ReadAllLines(filename);

            // Tokenize the text data
            var tokens = lines.SelectMany(line => line.Split(' '));

            // clean tokens from empty strings and spaces 
            var cleanTokens = tokens.Where(token => !string.IsNullOrWhiteSpace(token));

            // Create a list of tokens
            var tokenList = cleanTokens.Select(token => new Token(token)).ToList();

            return tokenList;
        }
    }
}
