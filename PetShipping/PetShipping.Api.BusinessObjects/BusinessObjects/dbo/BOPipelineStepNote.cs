using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOPipelineStepNote: AbstractBOPipelineStepNote, IBOPipelineStepNote
	{
		public BOPipelineStepNote(
			ILogger<PipelineStepNoteRepository> logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteModelValidator pipelineStepNoteModelValidator)
			: base(logger, pipelineStepNoteRepository, pipelineStepNoteModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2fcee222e229c88a8ec8a3a19db4aee8</Hash>
</Codenesium>*/