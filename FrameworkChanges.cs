namespace DemoLiberisProject
{
    internal class FrameworkChanges
    {
        // Compare two strings
        public void VerifyString(string expected, string actual)
        {
            if (expected.Equals(actual))
            {
                //Assert.Pass();
                Console.WriteLine("Test Passed");
            }
            else
            {
                //Assert.Fail();
                Console.WriteLine("Test Failed");
            }
        }
    }
}
