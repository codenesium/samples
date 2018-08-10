using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>70a68bd61f206a9d4854bb03a930ed29</Hash>
</Codenesium>*/