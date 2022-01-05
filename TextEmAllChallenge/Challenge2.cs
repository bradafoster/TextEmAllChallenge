using System.Linq;

namespace TextEmAllChallenge
{
    public class Challenge2
    {
        public int MaxDistance(string input)
        {
            // project the characters in the input string into a list of objects with the character,
            // the character's position within the input string, and the ascii character code
            var inputCharInfos = input.ToCharArray().Select((c, i) => new { Character = c, Position = i, CharacterCode = (int)c }).ToList();

            // calculate the max distance
            int maxDistance = inputCharInfos
                .SelectMany(a => inputCharInfos.Select(b => new[] { a, b })) // first create all the possible pairs of all the characters
                .Where(charInfoPair => charInfoPair[0].Position < charInfoPair[1].Position && charInfoPair[0].CharacterCode < charInfoPair[1].CharacterCode) // filter out the pairs where the positions are out of order or the 1st letter is after the 2nd letter in the alphabet
                .Select(charInfoArray => charInfoArray[1].CharacterCode - charInfoArray[0].CharacterCode - 1) // calculate the number of letters between the 2 letters in the alphabet, i.e. "distance"
                .Max(); // pick the max distance

            return maxDistance;
        }
    }
}
