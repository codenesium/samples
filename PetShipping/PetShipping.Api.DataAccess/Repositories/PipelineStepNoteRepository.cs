using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepNoteRepository: AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
	{
		public PipelineStepNoteRepository(
			ILogger<PipelineStepNoteRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4038f2855ac60acb25107d3c6a6e57c6</Hash>
</Codenesium>*/