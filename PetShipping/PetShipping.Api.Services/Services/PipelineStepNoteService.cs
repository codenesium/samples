using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepNoteService: AbstractPipelineStepNoteService, IPipelineStepNoteService
	{
		public PipelineStepNoteService(
			ILogger<PipelineStepNoteRepository> logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper BOLpipelineStepNoteMapper,
			IDALPipelineStepNoteMapper DALpipelineStepNoteMapper)
			: base(logger, pipelineStepNoteRepository,
			       pipelineStepNoteModelValidator,
			       BOLpipelineStepNoteMapper,
			       DALpipelineStepNoteMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>436eb30d14753fef54ce5f300435ca78</Hash>
</Codenesium>*/