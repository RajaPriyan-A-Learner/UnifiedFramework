namespace Framework.Core.Interfaces
{
    public interface IWebUI
    {
        void NavigateTo(string url);
        void Click(string locator);
        void Type(string locator, string text);
        string GetText(string locator);
        void Quit();

        object GetDriver(); // Expose the underlying driver for advanced use cases
    }
}
