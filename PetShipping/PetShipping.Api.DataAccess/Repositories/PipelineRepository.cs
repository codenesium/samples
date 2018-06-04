using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineRepository: AbstractPipelineRepository, IPipelineRepository
	{
		public PipelineRepository(
			ILogger<PipelineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e43c5cf10a9c2e1a39206b99849c1734</Hash>
</Codenesium>*/