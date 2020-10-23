namespace CodingPracticeAug2020
{
    using System;

    public class CeasarAlgorithm
    {
        private const int LetterA = 'A';
        private const int LetterCount = 'Z' - LetterA + 1;

        public int Offset;

        public CeasarAlgorithm()
        {
            var random = new Random();
            Offset = random.Next(0, LetterCount);
        }

        public CeasarAlgorithm(int offset)
        {
            Offset = offset;
        }

        public string Encrypt(string valueToEncrypt)
        {
            if (string.IsNullOrEmpty(valueToEncrypt))
            {
                throw new Exception("valueToEncrypt can't be null or empty");
            }

            return this.Shift(this.PrepareTextForEncyption(valueToEncrypt), this.Offset);
        }

        public string Decrypt(string valueToDecrypt)
        {
            if (string.IsNullOrEmpty(valueToDecrypt))
            {
                throw new Exception("valuetoDecrypt can't be null or empty");
            }

            return this.Shift(this.PrepareTextForDecryption(valueToDecrypt), -this.Offset);
        }

        private string Shift(string input, int shift)
        {
            var shiftedValue = string.Empty;
            var charArray = input.ToCharArray();

            for (var i = 0; i < charArray.Length; i++)
            {
                shiftedValue += (char)(LetterA + ((charArray[i] + shift - LetterA + LetterCount) % LetterCount));
            }

            return shiftedValue;
        }

        private string PrepareTextForEncyption(string text)
        {
            var preparedValue = this.RemoveSpaces(text);
            preparedValue.ToUpper();
            preparedValue = this.Reverse(preparedValue);
            return preparedValue;
        }

        private string PrepareTextForDecryption(string text)
        {
            return this.Reverse(text);
        }

        public string Reverse(string value)
        {
            var charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string RemoveSpaces(string value)
        {
            return value.Replace(" ", string.Empty);
        }
    }
}

