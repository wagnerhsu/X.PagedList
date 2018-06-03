using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace X.PagedList.Tests
{
    public class BugTest
    {
        private readonly ExampleService _someService = new ExampleService();

        [Fact]
        public void Test()
        {
            var articles = _someService.GetArticles(); // 0 articles in the list
            int pageNumber = 1;
            var pagedArticles = new PagedList<PartnerArticle>(articles, pageNumber, 9); // Exception here
        }
    }

    public class PartnerArticle
    {
    }

    internal class ExampleService
    {
        public IQueryable<PartnerArticle> GetArticles() => new List<PartnerArticle>().AsQueryable();
    }
}