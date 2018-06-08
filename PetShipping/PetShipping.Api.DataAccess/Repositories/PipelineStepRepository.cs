using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepRepository: AbstractPipelineStepRepository, IPipelineStepRepository
        {
                public PipelineStepRepository(
                        ILogger<PipelineStepRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>796f5c21255bc1ddcbe9c64ebec43671</Hash>
</Codenesium>*/