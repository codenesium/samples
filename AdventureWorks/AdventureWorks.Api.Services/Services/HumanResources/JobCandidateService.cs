using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class JobCandidateService : AbstractJobCandidateService, IJobCandidateService
        {
                public JobCandidateService(
                        ILogger<IJobCandidateRepository> logger,
                        IJobCandidateRepository jobCandidateRepository,
                        IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
                        IBOLJobCandidateMapper boljobCandidateMapper,
                        IDALJobCandidateMapper daljobCandidateMapper
                        )
                        : base(logger,
                               jobCandidateRepository,
                               jobCandidateModelValidator,
                               boljobCandidateMapper,
                               daljobCandidateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>356bffb3112901a3111c2a2f0a49b9c1</Hash>
</Codenesium>*/