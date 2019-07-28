using CaptureTheChris.Enums;

namespace CaptureTheChris.Enigma
{
    public class EnigmaField
    {
        public EnigmaField(EnigmaColor enigmaColor)
        {
            EnigmaColor = enigmaColor;
        }
        
        public EnigmaField(EnigmaColor enigmaColor, bool isGuessed)
        {
            EnigmaColor = enigmaColor;
            IsGuessed = isGuessed;
        }

        public EnigmaColor EnigmaColor { get; }
        
        public bool IsGuessed { get; private set; }

        public bool Guess(EnigmaColor enigmaColor)
        {
            if (enigmaColor != EnigmaColor) return false;
            
            IsGuessed = true;
            return true;
        }
    }
}