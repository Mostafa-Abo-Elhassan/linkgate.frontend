namespace LinkGate.frontend.Services.Shared
{
    public class LoadingService
    {
        // حدث يخبر المكونات عندما يتغير وضع التحميل
        public event Action<bool, string>? OnLoadingStateChanged;

        public void Show(string message = "جاري المعالجة...")
        {
            OnLoadingStateChanged?.Invoke(true, message);
        }

        public void Hide()
        {
            OnLoadingStateChanged?.Invoke(false, string.Empty);
        }
    }
}
