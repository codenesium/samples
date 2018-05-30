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
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper pipelineStepNoteMapper)
			: base(logger, pipelineStepNoteRepository, pipelineStepNoteModelValidator, pipelineStepNoteMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>dc1f5e0858c2ecb76dfb368cfeb230d1</Hash>
</Codenesium>*/