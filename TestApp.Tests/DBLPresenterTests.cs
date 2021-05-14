using NUnit.Framework;
using System.Configuration;
using DatabaseLayer;

namespace TestApp.Tests
{
    public class DBLPresenterTests
    {
        DBLPresenter testPresenter;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GotConnectionString()
        {
            testPresenter = new DBLPresenter();
            Assert.NotNull(testPresenter.ConnectionString);
        }

        [Test]
        public void NotEmptyMovies()
        {
            testPresenter = new DBLPresenter();
            Assert.NotNull(testPresenter.Movies);
        }
    }
}