using CalcTest.Contracts.Showmethecode;

namespace CalcTest.Data.Repository.Showmethecode
{
    public class ShowmethecodeRepository : IShowmethecodeRepository
    {
        private const string Git = @"https://github.com/Stefanoac/CalcTest";

        public string Get() => Git;
    }
}
