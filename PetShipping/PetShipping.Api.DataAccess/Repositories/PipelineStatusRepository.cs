using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineStatusRepository : AbstractPipelineStatusRepository, IPipelineStatusRepository
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
    <Hash>ee09152ec3b08532d4e94300f6b29170</Hash>
</Codenesium>*/