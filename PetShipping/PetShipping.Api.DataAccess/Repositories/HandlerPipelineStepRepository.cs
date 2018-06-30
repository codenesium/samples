using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class HandlerPipelineStepRepository : AbstractHandlerPipelineStepRepository, IHandlerPipelineStepRepository
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
    <Hash>de16bdbd66daf34126558199f403f2ee</Hash>
</Codenesium>*/