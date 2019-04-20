using System;
using UnityEngine;

namespace com.tdb.echo.Utils
{
    public struct GUIBackgroundColorScope : IDisposable
    {
        private Color _old;

        public GUIBackgroundColorScope(Color color)
        {
            this._old = GUI.backgroundColor;
            GUI.backgroundColor = color;
        }

        public void Dispose()
        {
            GUI.backgroundColor = this._old;
        }
    }
}