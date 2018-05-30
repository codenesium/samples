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
	public class PipelineStatusRepository: AbstractPipelineStatusRepository, IPipelineStatusRepository
	{
		public PipelineStatusRepository(
			IDALPipelineStatusMapper mapper,
			ILogger<PipelineStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>cec5465b51cf1bf32e0d4b7eb4baf066</Hash>
</Codenesium>*/