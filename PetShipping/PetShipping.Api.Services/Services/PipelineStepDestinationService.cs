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
	public partial class PipelineStepDestinationService : AbstractPipelineStepDestinationService, IPipelineStepDestinationService
	{
		public PipelineStepDestinationService(
			ILogger<IPipelineStepDestinationRepository> logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper bolpipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalpipelineStepDestinationMapper
			)
			: base(logger,
			       pipelineStepDestinationRepository,
			       pipelineStepDestinationModelValidator,
			       bolpipelineStepDestinationMapper,
			       dalpipelineStepDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>09329a19eb07ac1a4e747f75e1af9b4f</Hash>
</Codenesium>*/