using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepNoteService : AbstractPipelineStepNoteService, IPipelineStepNoteService
	{
		public PipelineStepNoteService(
			ILogger<IPipelineStepNoteRepository> logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper bolpipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalpipelineStepNoteMapper
			)
			: base(logger,
			       pipelineStepNoteRepository,
			       pipelineStepNoteModelValidator,
			       bolpipelineStepNoteMapper,
			       dalpipelineStepNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>82b12a676ea67ab876349b60f0328443</Hash>
</Codenesium>*/