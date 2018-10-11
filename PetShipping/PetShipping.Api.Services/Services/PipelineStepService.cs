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
	public partial class PipelineStepService : AbstractPipelineStepService, IPipelineStepService
	{
		public PipelineStepService(
			ILogger<IPipelineStepRepository> logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper bolpipelineStepMapper,
			IDALPipelineStepMapper dalpipelineStepMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base(logger,
			       pipelineStepRepository,
			       pipelineStepModelValidator,
			       bolpipelineStepMapper,
			       dalpipelineStepMapper,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper,
			       bolPipelineStepStepRequirementMapper,
			       dalPipelineStepStepRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>02cc34266d5cf013861beb1c40019365</Hash>
</Codenesium>*/