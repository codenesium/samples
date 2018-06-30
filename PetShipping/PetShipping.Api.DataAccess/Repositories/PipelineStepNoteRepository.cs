using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineStepNoteRepository : AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
        {
                public PipelineStepNoteRepository(
                        ILogger<PipelineStepNoteRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>193e8a7d7189d9513dbc1ade165f55c5</Hash>
</Codenesium>*/