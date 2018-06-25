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
        public partial class MutexService : AbstractMutexService, IMutexService
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
    <Hash>3a2735d8946488d7e9c361a08bf23bf9</Hash>
</Codenesium>*/