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
	public class BOPipelineStep: AbstractBOPipelineStep, IBOPipelineStep
	{
		public BOPipelineStep(
			ILogger<PipelineStepRepository> logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepModelValidator pipelineStepModelValidator)
			: base(logger, pipelineStepRepository, pipelineStepModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>857a05544b83efb06648af40ecb4d2d9</Hash>
</Codenesium>*/