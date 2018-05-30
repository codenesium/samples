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
	public class BOPipelineStepDestination: AbstractBOPipelineStepDestination, IBOPipelineStepDestination
	{
		public BOPipelineStepDestination(
			ILogger<PipelineStepDestinationRepository> logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper pipelineStepDestinationMapper)
			: base(logger, pipelineStepDestinationRepository, pipelineStepDestinationModelValidator, pipelineStepDestinationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>370b253b2adcfd4b88145ccd15865b61</Hash>
</Codenesium>*/