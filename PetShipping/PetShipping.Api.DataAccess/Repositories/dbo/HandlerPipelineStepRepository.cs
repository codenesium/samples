using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class HandlerPipelineStepRepository: AbstractHandlerPipelineStepRepository, IHandlerPipelineStepRepository
	{
		public HandlerPipelineStepRepository(
			IDALHandlerPipelineStepMapper mapper,
			ILogger<HandlerPipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b6357eb1cfd2a3cb05eb2c050cb4d8ed</Hash>
</Codenesium>*/