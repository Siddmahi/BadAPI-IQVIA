using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BadAPISolution.BusinessComponent
{
    public class BusinessComponentFactory
    {
        private const int NOT_INITIALIZED = 0;
        private const int INITIALIZED = 1;

        private static IGetTweetsBusinessComponent getTweetsBusinessComponent;
        private static readonly object getTweetsBusinessComponentLock = new object();
        private static int getTweetsBusinessComponentStatus;
        public static IGetTweetsBusinessComponent GetTweetsBusinessComponent
        {
            get
            {
                if (Thread.VolatileRead(ref getTweetsBusinessComponentStatus) == NOT_INITIALIZED)
                {
                    lock (getTweetsBusinessComponentLock)
                    {
                        if (getTweetsBusinessComponentStatus == NOT_INITIALIZED)
                        {
                            getTweetsBusinessComponent = new GetTweetsBusinessComponent();
                            getTweetsBusinessComponentStatus = INITIALIZED;
                        }
                    }
                }
                return getTweetsBusinessComponent;
            }
        }
    }
}
