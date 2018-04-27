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
			IPipelineStepModelValidator pipelineStepModelValidator)
			: base(logger, pipelineStepRepository, pipelineStepModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ea560d5c089a4de6b5ec24689180c6db</Hash>
</Codenesium>*/