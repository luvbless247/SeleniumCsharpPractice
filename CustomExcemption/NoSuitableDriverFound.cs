using SpecFlowPracticeTest.Configuration;

namespace SpecFlowPracticeTest.CustomExcemption
{
    public class NoSuitableDriverFound : Exception
    {
        public NoSuitableDriverFound(string msg) : base(msg)
        {

        }
    }
}
