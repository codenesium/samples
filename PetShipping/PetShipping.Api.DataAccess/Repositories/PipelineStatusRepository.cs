using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStatusRepository: AbstractPipelineStatusRepository, IPipelineStatusRepository
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
    <Hash>c6923565e4b4f63791cf71e7c1036e70</Hash>
</Codenesium>*/