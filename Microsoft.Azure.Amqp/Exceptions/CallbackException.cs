// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Amqp
{
    using System;
    using System.Runtime.Serialization;

#if NET45 || MONOANDROID
    [Serializable]
#endif
    class CallbackException : FatalException
    {
        public CallbackException()
        {
        }

        public CallbackException(string message, Exception innerException)
            : base(message, innerException)
        {
            // This cannot throw something like ArgumentException because that would be worse than
            // throwing the callback exception that was requested.
            Fx.Assert(innerException != null, "CallbackException requires an inner exception.");
            Fx.Assert(!Fx.IsFatal(innerException), "CallbackException can't be used to wrap fatal exceptions.");
        }

#if NET45 || MONOANDROID
        protected CallbackException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
