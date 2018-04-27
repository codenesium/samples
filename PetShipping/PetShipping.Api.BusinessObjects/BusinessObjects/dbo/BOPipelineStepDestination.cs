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
			IPipelineStepDestinationModelValidator pipelineStepDestinationModelValidator)
			: base(logger, pipelineStepDestinationRepository, pipelineStepDestinationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7994e43f2aa6e03a8a5308cfb15fd5ce</Hash>
</Codenesium>*/