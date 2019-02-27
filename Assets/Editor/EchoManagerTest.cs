using NUnit.Framework;
using com.tdb.echo;
using com.tdb.echo.test.mock;

public class EchoManagerTest {

    [Test]
    public void CanAddDuplicateLogHandler_ReturnFalse()
    {
        EchoManager.Reset();
        EchoManager.Instance.AddLogHandler<MockLogHandler>();
        EchoManager.Instance.AddLogHandler<MockLogHandler>();
    }

}
