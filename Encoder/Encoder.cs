using System;
using System.Collections.Generic;
using System.Linq;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
            string retValue = string.Empty;
            string Vowels = "aeiou";
            string Consonants = "bcdfghjklmnpqrstvwxz";
            string Numbers = "0123456789";
            //Implement your code here!
            //throw new NotImplementedException();
            message = message.ToLower();

            List<PartString> partStrings = new List<PartString>();
            //Put all part values in a partString list
            for (int i = 0; i < message.Length; i++)
            {
                PartString partString = new PartString();
                if (Vowels.Contains(message[i]))
                {
                    partString.PartType = StringPartType.Vowel;
                }
                else if (Consonants.Contains(message[i]))
                {
                    partString.PartType = StringPartType.Consonant;
                }
                else if (message[i] == 'y')
                {
                    partString.PartType = StringPartType.Y;
                }
                else if (message[i] == ' ')
                {
                    partString.PartType = StringPartType.Space;
                }
                else if (Numbers.Contains(message[i]))
                {
                    partString.PartType = StringPartType.Number;
                }
                else
                {
                    partString.PartType = StringPartType.Unchanged;
                }
                partString.PartValue = Convert.ToString(message[i]);

                if (i > 0 && partString.PartType == StringPartType.Number)
                {
                    PartString lastItem = partStrings.Last();
                    if (lastItem.PartType == StringPartType.Number)
                    {
                        lastItem.PartValue = lastItem.PartValue + partString.PartValue;
                    }
                    else
                    {
                        partStrings.Add(partString);
                    }
                }
                else
                {
                    partStrings.Add(partString);
                }
            }
            //change all part values of partString list
            for (int i = 0; i < partStrings.Count; i++)
            {
                PartString changedPart = partStrings[i];
                switch (changedPart.PartType)
                {
                    case StringPartType.Vowel:
                        if (changedPart.PartValue == "a") { changedPart.PartValue = "1"; }
                        else if (changedPart.PartValue == "e") { changedPart.PartValue = "2"; }
                        else if (changedPart.PartValue == "i") { changedPart.PartValue = "3"; }
                        else if (changedPart.PartValue == "o") { changedPart.PartValue = "4"; }
                        else if (changedPart.PartValue == "u") { changedPart.PartValue = "5"; }
                        break;
                    case StringPartType.Consonant:
                        if (changedPart.PartValue == "b") { changedPart.PartValue = "a"; }
                        else if (changedPart.PartValue == "c") { changedPart.PartValue = "b"; }
                        else if (changedPart.PartValue == "d") { changedPart.PartValue = "c"; }
                        else if (changedPart.PartValue == "f") { changedPart.PartValue = "e"; }
                        else if (changedPart.PartValue == "g") { changedPart.PartValue = "f"; }
                        else if (changedPart.PartValue == "h") { changedPart.PartValue = "g"; }
                        else if (changedPart.PartValue == "j") { changedPart.PartValue = "i"; }
                        else if (changedPart.PartValue == "k") { changedPart.PartValue = "j"; }
                        else if (changedPart.PartValue == "l") { changedPart.PartValue = "k"; }
                        else if (changedPart.PartValue == "m") { changedPart.PartValue = "l"; }
                        else if (changedPart.PartValue == "n") { changedPart.PartValue = "m"; }
                        else if (changedPart.PartValue == "p") { changedPart.PartValue = "o"; }
                        else if (changedPart.PartValue == "q") { changedPart.PartValue = "p"; }
                        else if (changedPart.PartValue == "r") { changedPart.PartValue = "q"; }
                        else if (changedPart.PartValue == "s") { changedPart.PartValue = "r"; }
                        else if (changedPart.PartValue == "t") { changedPart.PartValue = "s"; }
                        else if (changedPart.PartValue == "v") { changedPart.PartValue = "u"; }
                        else if (changedPart.PartValue == "w") { changedPart.PartValue = "v"; }
                        else if (changedPart.PartValue == "x") { changedPart.PartValue = "w"; }
                        else if (changedPart.PartValue == "z") { changedPart.PartValue = "y"; }
                        break;
                    case StringPartType.Y:
                        changedPart.PartValue = " ";
                        break;
                    case StringPartType.Space:
                        changedPart.PartValue = "y";
                        break;
                    case StringPartType.Number:
                        changedPart.PartValue = new string(changedPart.PartValue.Reverse().ToArray());
                        break;
                    case StringPartType.Unchanged:
                        break;
                    default:
                        break;
                }
                partStrings[i] = changedPart;
            }

            //Concat all changed part string to return string
            partStrings.ForEach(a => retValue = string.Concat(retValue, a.PartValue)); ;
            return retValue;
        }
    }
    public class PartString
    {
        public string PartValue { get; set; }
        public StringPartType PartType { get; set; }
    }
    public enum StringPartType
    {
        Vowel,
        Consonant,
        Y,
        Space,
        Number,
        Unchanged
    }
}