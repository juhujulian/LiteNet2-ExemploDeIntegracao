namespace Toletus.LiteNet2.Challenge
{
    public class ChallengeRequired
    {
        public const string LastFirmwareVersionRequireChallenge = "2.0.0 R1";

        public static bool Check(string firmwareVersion)
        {
            return string.CompareOrdinal(firmwareVersion, LastFirmwareVersionRequireChallenge) <= 0;
        }
    }
}
