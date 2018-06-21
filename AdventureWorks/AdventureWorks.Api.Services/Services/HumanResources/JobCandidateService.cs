using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
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
    <Hash>98bc112f4f836eba0c34bd75bc3a6d48</Hash>
</Codenesium>*/