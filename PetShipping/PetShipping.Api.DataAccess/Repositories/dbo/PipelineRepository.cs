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
			IObjectMapper mapper,
			ILogger<PipelineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b8b22bab4603fa963a671f5008afcfaf</Hash>
</Codenesium>*/