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
			IPipelineStepNoteModelValidator pipelineStepNoteModelValidator)
			: base(logger, pipelineStepNoteRepository, pipelineStepNoteModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>69c07332c0cfb311eccc0bb5f8b9c343</Hash>
</Codenesium>*/