using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class WindowHelper
    {
        public static string GetTile()
        {
            return ObjectRepository.Driver.Title;
        }
    }
}
