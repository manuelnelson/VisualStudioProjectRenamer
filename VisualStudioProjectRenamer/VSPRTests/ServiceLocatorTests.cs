using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSPRBase.Common;

namespace VSPRTests
{
    using VSPRInterfaces;

    /// <summary>
    /// Summary description for ServiceLocatorTests
    /// </summary>
    [TestClass]
    public class ServiceLocatorTests
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        public void ShouldReturnSingletonForILocalizationService()
        {
            ServiceLocator.Initialize();

            ILocalizationService localizationService = ServiceLocator.GetInstance<ILocalizationService>();
            localizationService.SetCulture("de-DE");

            Assert.AreEqual(localizationService.CurrentCulture.Name, "de-DE");

            // Get the same instance by requesting it again from the container, culture now should be de-DE
            ILocalizationService localizationService1 = ServiceLocator.GetInstance<ILocalizationService>();

            Assert.AreEqual(localizationService.CurrentCulture.Name, "de-DE");
        }
    }
}