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
			IApiPipelineModelValidator pipelineModelValidator)
			: base(logger, pipelineRepository, pipelineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7f1f8aa92ca7b6203a55dd5814811e48</Hash>
</Codenesium>*/