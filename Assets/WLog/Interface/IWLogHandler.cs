using UnityEngine;

namespace com.tdb.w
{
    public interface IWLogHandler
    {
        void Log(WLogMessage message);
    }
}