using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class PipelineStepStatusRepository: AbstractPipelineStepStatusRepository, IPipelineStepStatusRepository
	{
		public PipelineStepStatusRepository(
			ILogger<PipelineStepStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>0daf1b06f4fea115009710647e010e5b</Hash>
</Codenesium>*/