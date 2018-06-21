using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineRepository : AbstractPipelineRepository, IPipelineRepository
        {
                public PipelineRepository(
                        ILogger<PipelineRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6a1e351b0294c4676c7799487a473f60</Hash>
</Codenesium>*/