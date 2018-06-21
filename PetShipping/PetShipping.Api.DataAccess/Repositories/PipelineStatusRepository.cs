using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>0df0203206cf7d80ebcafd0fba38408c</Hash>
</Codenesium>*/