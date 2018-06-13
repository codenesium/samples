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
                        ILogger<MutexRepository> logger,
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
    <Hash>87f926b4297dee5b6cff0e0244789f25</Hash>
</Codenesium>*/