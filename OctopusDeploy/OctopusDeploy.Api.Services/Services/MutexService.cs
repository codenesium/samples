using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class MutexService: AbstractMutexService, IMutexService
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
                               dalmutexMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e5e0dd7a1d209d60d72544ca448f7efc</Hash>
</Codenesium>*/