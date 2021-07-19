namespace HyperAutomation.ControlRoom.Shared.Cryptography.Provider
{
    public interface ICryptographyProvider
    {
        string Encrypt(
            string info);

        string DeCrypt(
            string info);
    }
}
