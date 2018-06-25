using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineRepository : AbstractPipelineRepository, IPipelineRepository
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
    <Hash>a32b3b19cb8a4b0cd09af1b2b727767a</Hash>
</Codenesium>*/