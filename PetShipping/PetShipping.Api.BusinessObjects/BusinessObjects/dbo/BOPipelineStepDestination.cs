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
			IApiPipelineStepDestinationModelValidator pipelineStepDestinationModelValidator)
			: base(logger, pipelineStepDestinationRepository, pipelineStepDestinationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>fc4b414039b098144ef372890dad6997</Hash>
</Codenesium>*/