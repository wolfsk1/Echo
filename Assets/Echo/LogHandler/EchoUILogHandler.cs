using System.Collections.Generic;

namespace com.tdb.echo
{
    public class EchoUILogHandler : IEchoLogHandler
    {
        public void Log(EchoMessage message)
        {
        }

        private List<EchoMessage> _recordLogList;
    }
}