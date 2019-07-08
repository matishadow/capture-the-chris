using CaptureTheChris.Enums;

namespace CaptureTheChris.Enigma
{
    public class EnigmaField
    {
        public EnigmaField(EnigmaColor enigmaColor)
        {
            EnigmaColor = enigmaColor;
        }

        public EnigmaColor EnigmaColor { get; }
        
        public bool IsGuessed { get; private set; }

        public void Guess(EnigmaColor enigmaColor)
        {
            if (enigmaColor == EnigmaColor)
                IsGuessed = true;
        }
    }
}