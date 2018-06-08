using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class JobCandidateRepository: AbstractJobCandidateRepository, IJobCandidateRepository
        {
                public JobCandidateRepository(
                        ILogger<JobCandidateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5ddfa99a1e7c2f3fe4f2a565e0bf4817</Hash>
</Codenesium>*/