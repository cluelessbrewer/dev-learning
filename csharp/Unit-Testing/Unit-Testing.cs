

/*************** Unit Testing ************** */

// Arrange, Act, Assert
// Arrange - 
// Act - 
// Assert - Valdiate result returned is correct.

// (Red, Green, Refactor) & Repeat

// unit testing naming conventions - [UnitOfWork_StateUnderTest_ExpectedBehavior]
// Dont put method name in unit test name as if the method name is refactored the test is not updated.

// Examples: 
// - Deposit_ShouldIncreaseBalance_WhenGivenPositiveValue()
// - increasesBalanceWhenDepositIsMade()

// Assertions:
// Assert.AreEqual( int expected, int actual, string message, params object[] parms );
// Assert.AreNotEqual( int expected, int actual, string message, params object[] parms );
// Assert.AreSame( object expected, object actual, string message, params object[] parms );
// Assert.AreNotSame( object expected, object actual, string message, params object[] parms );
// Assert.Contains( object anObject, IList collection );
// Assert.IsTrue( bool condition, string message );
// Assert.IsFalse( bool condition, string message );
// Assert.IsNull( object anObject, string message );
// Assert.Null( object anObject, string message );
// Assert.IsNotNull( object anObject );
// Assert.NotNull( object anObject );
// Assert.IsNaN( double aDouble, string message );
// Assert.IsEmpty( string aString, string message );
// Assert.IsNotEmpty( string aString, string message );
// Assert.GreaterOrEqual( int arg1, int arg2, string message ); // LessOrEqual, Less, Greater
// Assert.IsInstanceOfType( Type expected, object actual );
// Assert.IsNotInstanceOfType( Type expected, object actual );
// Assert.IsAssignableFrom( Type expected, object actual );
// Assert.IsNotAssignableFrom( Type expected, object actual );
// Assert.IsInstanceOf<T>( object actual, string message );
// Assert.IsAssignableFrom<T>( object actual );
// Assert.Throws( Type expectedExceptionType, TestDelegate code );
// Assert.Throws( IResolveConstraint constraint, TestDelegate code );
// Assert.Throws<T>( TestDelegate code, string message );
// CollectionAssert.AllItemsAreInstancesOfType( IEnumerable collection, Type expectedType );
// CollectionAssert.IsSubsetOf( IEnumerable subset, IEnumerable superset );
// CollectionAssert.IsNotSubsetOf( IEnumerable subset, IEnumerable superset);
// FileAssert.AreEqual( Stream expected, Stream actual );
// DirectoryAssert.AreEqual( DirectoryInfo expected, DirectoryInfo actual );

// Nunit:
// The [TestFixture] attribute denotes a class that contains unit tests. The [Test] attribute indicates a method is a test method.
// A [TestCase] attribute is used to create a suite of tests that execute the same code but have different input arguments. 
// You can use the [TestCase] attribute to specify values for those inputs.

// [ExpectedException(typeOf(CustomerErrorTypeOrNativeErrorType))]

// [Category("LongRunning")]
// The Category attribute provides an alternative to suites for dealing with groups of tests. 

// [Test, Combinatorial]
// public void MyTest(
//     [Values(1, 2, 3)] int x,
//     [Values("A", "B")] string s)
// {
//     ...
// }
// The CombinatorialAttribute is used on a test to specify that NUnit should generate test cases for all possible combinations of 
// the individual data items provided for the parameters of a test. Since this is the default, use of this attribute is optional.

// [Test, Timeout(2000)]
// [Test, MaxTime(2000)]
// The MaxTimeAttribute is used on test methods to specify a maximum time in milliseconds for a test case.
// If the test case takes longer than the specified time to complete, it is reported as a failure.

// [Test, Order(1)]
// The OrderAttribute may be placed on a test method or fixture to specify the order in which tests are run. 
// Ordering is given by the required order argument to the attribute, an int.

// [Platform(Exclude="Win98,WinME")]
// Platorm specific tests

// Example
// The following test will be executed fifteen times, three times for each value of x, each combined with 5 random doubles from -1.0 to +1.0.
// [Test]
// public void MyTest(
//     [Values(1, 2, 3)] int x,
//     [Random(-1.0, 1.0, 5)] double d)
// {
//     ...
// }

// [SetCulture("fr-FR")]
// Change culture for that test only. Changes back to what it was once finished.

// [SetUp] [TearDown] 
// This attribute is used inside a TestFixture to provide a common set of functions that are performed just before each test method is called.

// [SetUpFixture]
// This is the attribute that marks a class that contains the one-time setup or teardown methods for all the test fixtures under a given namespace. 
// The class may contain at most one method marked with the OneTimeSetUpAttribute and one method marked with the OneTimeTearDownAttribute.
//
// SetUp/TearDown run after every test. SetUpFixture run before and after all tests.
// [OneTimeSetUp]
// public void RunBeforeAnyTests()
// [OneTimeTearDown]
// public void RunAfterAnyTests()
//
// SingleThreadedAttribute is used on a TestFixture and indicates that the OneTimeSetUp, 
// OneTimeTearDown and all the child tests must run on the same thread.

// Test methods targeting .Net 4.0 or higher may be marked as async and NUnit will wait for the method to complete before
// recording the result and moving on to the next test. Async test methods must return Task if no value is returned,
// or Task<T> if a value of type T is returned.

// [Values]
// public void MyBoolTest([Values]bool value)

// [TestCase(12, 3, ExpectedResult=4)]

// Nunit & Moq:
// Strict behavior means that exceptions will be thrown if anything that was not set up on our interface is called. 
// Loose behavior, on the other hand, does not throw exceptions in situations like this. Mocks, by default, are loose.

// Setup() can be used for mocking a method or a property.

// SetupGet() is specifically for mocking the getter of a property. If you use Setup() on a property getter, it will call SetupGet()
// So in that case, it is probably more personal preference as to whether you want to be more explicit and use SetupGet() instead of Setup().

// Times.Once, Times.Many (making sure the method is only run as many times as required
// Another option is to create a mock repository. By using a mock repository, we can verify all of the mocks we create in one place, 
// creating consistent verification without repetitive code for each test.)

// Dto = Data transfer object

#region NUnit-Moq

// Really good example of Mock 

// This assumes that there is an existing ICreditDecisionService interface
// and that CreditDecisionService implements it.
public class CreditDecision{

    ICreditDecisionService creditDecisionService; // Interface here is very important
    public CreditDecision(ICreditDecisionService creditDecisionService)
    {
        this.creditDecisionService = creditDecisionService;
    }

    public string MakeCreditDecision(int creditScore){
       return creditDecisionService.GetCreditDecision(creditScore);
    }
}

 [TestFixture]
    public class CreditDecisionTests
    {
        Mock<ICreditDecisionService>  mockCreditDecisionService;

        CreditDecision systemUnderTest;

        [TestCase(100, "Declined")]
        [TestCase(549, "Declined")]
        [TestCase(550, "Maybe")]
        [TestCase(674, "Maybe")]
        [TestCase(675, "We look forward to doing business with you!")]
        public void MakeCreditDecision_Always_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            mockCreditDecisionService = new Mock<ICreditDecisionService>(MockBehavior.Strict);
            mockCreditDecisionService.Setup(p => p.GetDecision(creditScore)).Returns(expectedResult);


            systemUnderTest = new CreditDecision(mockCreditDecisionService.Object);
            var result = systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));

            mockCreditDecisionService.VerifyAll();
        }
    }


[TestFixture]
public class FooTest2
    {
    class ConsumerOfIUser
    {
        public int Consume(IUser user)
        {
            return user.CalculateAge() + 10;
        }
    }
    
    [Test]
    public void DoWorkTest()
    {
        var userMock = new Mock<IUser>();
        userMock.Setup(u => u.CalculateAge()).Returns(10);

        var consumer = new ConsumerOfIUser();
        var result = consumer.Consume(userMock);

        Assert.AreEqual(result, 20); //should be true
    }

}
[TestFixture]
public class FooTest 
{
    Foo subject;
    Mock myInterfaceMock;

    [SetUp]
    public void SetUp()
    {
        // myInterfaceMock = MockRepository.Create();   // Alternative approach (instead of Mock) to use VerifyAll etc
        myInterfaceMock = new Mock();
        subject = new Foo();
    }

    [Test]
    public void DoWorkTest()
    {
        // Set up the mock
        myInterfaceMock.Setup(m => m.DoesSomething()).Returns(true);
        myInterfaceMock.SetupGet(m => m.Name).Returns("Molly");

        var result = subject.DoWork();

        // Verify that DoesSomething was called only once
        myInterfaceMock.Verify((m => m.DoesSomething()), Times.Once());

        // Verify that DoesSomething was never called
        myInterfaceMock.Verify((m => m.DoesSomething()), Times.Never());
    }
}

#endregion

#region NUnit-NoMockFramwork
//using NUnit.Framework;
//using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    { 
        // Interface instead of actualy service
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        // No the right way to do it.
        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }

        // Right way to do it
        #region Sample_TestCode
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
        #endregion
    }
}

// Clever use to provide data to method
// https://github.com/nunit/docs/wiki/TestCaseSource-Attribute
public class MyTestClass
{
    [TestCaseSource(typeof(DivideCases))]
    public void DivideTest(int n, int d, int q)
    {
        Assert.AreEqual(q, n / d);
    }
}

class DivideCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { 12, 3, 4 };
        yield return new object[] { 12, 2, 6 };
        yield return new object[] { 12, 4, 3 };
    }
}

static int[] EvenNumbers = new int[] { 2, 4, 6, 8 };

[Test, TestCaseSource("EvenNumbers")]
public void TestMethod(int num)
{
    Assert.IsTrue(num % 2 == 0);
}

// https://github.com/nunit/docs/wiki/TestFixtureSource-Attribute
[TestFixtureSource(typeof(AnotherClass), "FixtureArgs")]
public class MyTestClass
{
    public MyTestClass(string word, int num) { }
}

class AnotherClass
{
    static object [] FixtureArgs = {
        new object[] { "Question", 1 },
        new object[] { "Answer", 42 }
    };
}

#endregion


