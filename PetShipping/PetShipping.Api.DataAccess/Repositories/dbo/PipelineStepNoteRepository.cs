using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepNoteRepository: AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
	{
		public PipelineStepNoteRepository(
			IDALPipelineStepNoteMapper mapper,
			ILogger<PipelineStepNoteRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>16069d98b22344daf2b7cd9975aed7fb</Hash>
</Codenesium>*/