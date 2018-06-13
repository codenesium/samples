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
                        ILogger<JobCandidateRepository> logger,
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
    <Hash>59aefa500feb254ef6417552da1ef2dc</Hash>
</Codenesium>*/