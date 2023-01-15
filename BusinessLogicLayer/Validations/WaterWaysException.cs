using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    [Serializable]
    public class WaterWaysException: Exception
    {
        public WaterWaysException()
        { }

        public WaterWaysException(string message)
            : base(message)
        { }

        public WaterWaysException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected WaterWaysException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
