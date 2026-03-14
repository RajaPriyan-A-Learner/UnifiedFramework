namespace Framework.Core.Interfaces
{
    public interface IMobileUI
    {
        void Tap(string locator);
        void Type(string locator, string text);
        string GetText(string locator);
        void Quit();
    }
}