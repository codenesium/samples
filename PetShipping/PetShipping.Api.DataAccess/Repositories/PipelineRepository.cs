using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineRepository : AbstractPipelineRepository, IPipelineRepository
	{
		public PipelineRepository(
			ILogger<PipelineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e3be52c0d63ee0f2edf09b1ca78657f3</Hash>
</Codenesium>*/