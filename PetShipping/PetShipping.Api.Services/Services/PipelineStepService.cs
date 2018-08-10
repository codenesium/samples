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
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper
			)
			: base(logger,
			       pipelineStepRepository,
			       pipelineStepModelValidator,
			       bolpipelineStepMapper,
			       dalpipelineStepMapper,
			       bolHandlerPipelineStepMapper,
			       dalHandlerPipelineStepMapper,
			       bolOtherTransportMapper,
			       dalOtherTransportMapper,
			       bolPipelineStepDestinationMapper,
			       dalPipelineStepDestinationMapper,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper,
			       bolPipelineStepStepRequirementMapper,
			       dalPipelineStepStepRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2631ba04800f4e1a174e1a873fa5b1f1</Hash>
</Codenesium>*/