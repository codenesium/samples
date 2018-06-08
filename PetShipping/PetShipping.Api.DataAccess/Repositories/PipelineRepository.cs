using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineRepository: AbstractPipelineRepository, IPipelineRepository
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
    <Hash>88d1b837e86812f51c2a9c81056c2008</Hash>
</Codenesium>*/