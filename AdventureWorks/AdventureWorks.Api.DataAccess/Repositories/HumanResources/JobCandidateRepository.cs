using Codenesium.DataConversionExtensions;
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
    <Hash>6467f8599f9ecd9088fe586d67fb71b9</Hash>
</Codenesium>*/