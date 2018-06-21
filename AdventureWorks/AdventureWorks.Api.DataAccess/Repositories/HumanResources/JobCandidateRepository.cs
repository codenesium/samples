using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class JobCandidateRepository : AbstractJobCandidateRepository, IJobCandidateRepository
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
    <Hash>04db020397a4c72da1d94973cdee70b3</Hash>
</Codenesium>*/