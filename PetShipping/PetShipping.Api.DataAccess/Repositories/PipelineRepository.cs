using Codenesium.DataConversionExtensions;
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
    <Hash>76275d41977ba6825c8b5f70bbb22c39</Hash>
</Codenesium>*/