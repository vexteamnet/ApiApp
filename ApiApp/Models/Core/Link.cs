using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [Serializable]
    public class SerializableDynamic : DynamicObject, ISerializable
    {
        private readonly Dictionary<string, object> members = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = value;
            return true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var keyValuePair in members)
            {
                info.AddValue(keyValuePair.Key, keyValuePair.Value.ToString());
            }
        }
    }
}