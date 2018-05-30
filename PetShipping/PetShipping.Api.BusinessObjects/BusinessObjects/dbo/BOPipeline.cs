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
	public class BOPipeline: AbstractBOPipeline, IBOPipeline
	{
		public BOPipeline(
			ILogger<PipelineRepository> logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper pipelineMapper)
			: base(logger, pipelineRepository, pipelineModelValidator, pipelineMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3aad3895e7a12ebbfbcd41b0fa465c66</Hash>
</Codenesium>*/