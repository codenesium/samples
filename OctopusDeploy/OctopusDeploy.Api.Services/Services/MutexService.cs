using Codenesium.DataConversionExtensions;
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
    <Hash>617d7adff82e69c10725384574142bad</Hash>
</Codenesium>*/