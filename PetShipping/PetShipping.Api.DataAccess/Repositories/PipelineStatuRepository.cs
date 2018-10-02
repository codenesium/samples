using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStatuRepository : AbstractPipelineStatuRepository, IPipelineStatuRepository
	{
		public PipelineStatuRepository(
			ILogger<PipelineStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4754ac0c4cebe807c66001aaf0830723</Hash>
</Codenesium>*/