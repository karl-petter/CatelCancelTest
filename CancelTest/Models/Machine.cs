using Catel.Data;

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if !SILVERLIGHT
[Serializable]
#endif
public class Machine : ModelBase
{
    public Machine() {
    }

#if !SILVERLIGHT
    protected Machine(SerializationInfo info, StreamingContext context)
        : base(info, context) {
    }
#endif

    public Boolean Running
    {
        get { return GetValue<Boolean>(RunningProperty); }
        set { SetValue(RunningProperty, value); }
    }

    public static readonly PropertyData RunningProperty = RegisterProperty("Running", typeof(Boolean), null);
}
