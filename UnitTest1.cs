namespace SeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1 method execution");

        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2 method execution");

        }
        [TearDown]
        public void Closebrowser()
        {
           
            
           TestContext.Progress.WriteLine("TearDown method execution");

            
        }
    }
}