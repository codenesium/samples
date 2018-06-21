using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStatusRepository : AbstractPipelineStatusRepository, IPipelineStatusRepository
        {
                public PipelineStatusRepository(
                        ILogger<PipelineStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>23a266c063a17dd52ec9a6ff2270235f</Hash>
</Codenesium>*/