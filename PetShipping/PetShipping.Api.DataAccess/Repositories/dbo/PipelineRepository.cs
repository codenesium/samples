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
	public class PipelineRepository: AbstractPipelineRepository, IPipelineRepository
	{
		public PipelineRepository(
			IDALPipelineMapper mapper,
			ILogger<PipelineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>9601d7b0fe3a8716a03f4218a8581cb8</Hash>
</Codenesium>*/