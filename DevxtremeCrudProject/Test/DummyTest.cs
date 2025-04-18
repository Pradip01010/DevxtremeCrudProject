using DevExtreme.AspNet.Data.Helpers;

namespace DevxtremeCrudProject.Test
{
    public class DummyTest
    {
        public void Try()
        {
            var options = new DataSourceLoadOptions(); // ✅ This line should NOT show any red underline
        }
    }
}
