using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace com.tdb.echo
{
    [CreateAssetMenu(fileName = "newFilter",menuName = "Echo/New Filter")]
    public class EchoFilter : ScriptableObject
    {
        [SerializeField]
        public string Name = String.Empty;

        //public string[] ClassName;
        [SerializeField]
        private List<string> _tags = new List<string>();

        public string GetTags()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var tag in _tags)
            {
                sb.Append(tag);
                sb.Append(';');
            }
            return sb.ToString();
        }

        public void SetTags(string tagString)
        {
            var ss = tagString.Split(';');
            _tags.Clear();
            foreach (var s in ss)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    _tags.Add(s);
                }
            }
        }
    }

}

