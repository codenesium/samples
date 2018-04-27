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
			IPipelineModelValidator pipelineModelValidator)
			: base(logger, pipelineRepository, pipelineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d79f899cde010d9361e784b0c5494fda</Hash>
</Codenesium>*/