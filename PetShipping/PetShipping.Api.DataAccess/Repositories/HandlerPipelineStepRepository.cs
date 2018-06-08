using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class HandlerPipelineStepRepository: AbstractHandlerPipelineStepRepository, IHandlerPipelineStepRepository
        {
                public HandlerPipelineStepRepository(
                        ILogger<HandlerPipelineStepRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>59a4267bd3d437dc6a2731a7b507f9fa</Hash>
</Codenesium>*/