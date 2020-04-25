using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.EncryptionBuddy.Areas.SubAreas.Rijndael.Models
{
    public class RijndaelSecrets
    {
        public byte[] InitialVector { get; }
        public byte[] Key { get; }

        public RijndaelSecrets(byte[] initialVector, byte[] key)
        {
            Guard.ObjectNotNull(() => initialVector);
            Guard.ObjectNotNull(() => key);
            Guard.That(() => initialVector.Length == 16, "Initial vector must be 16 bytes");
            Guard.That(() => key.Length == 32, "Key must be 32 bytes");

            InitialVector = initialVector;
            Key = key;
        }
    }
}