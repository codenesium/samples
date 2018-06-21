using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class MutexService : AbstractMutexService, IMutexService
        {
                public MutexService(
                        ILogger<IMutexRepository> logger,
                        IMutexRepository mutexRepository,
                        IApiMutexRequestModelValidator mutexModelValidator,
                        IBOLMutexMapper bolmutexMapper,
                        IDALMutexMapper dalmutexMapper
                        )
                        : base(logger,
                               mutexRepository,
                               mutexModelValidator,
                               bolmutexMapper,
                               dalmutexMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>920f0136742220cceeac737ae16a8ad3</Hash>
</Codenesium>*/