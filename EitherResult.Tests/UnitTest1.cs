using Xunit;

namespace EitherResult.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            
            var x = 12.Left<int, string>();
            x.Switch(left => { }, right => { });
        }
    }
}