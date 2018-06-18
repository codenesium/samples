using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class JobCandidateService: AbstractJobCandidateService, IJobCandidateService
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
                               daljobCandidateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>44a8653776cda4ed6034114bb30e71d9</Hash>
</Codenesium>*/