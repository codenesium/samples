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
	public partial class PipelineStepRepository : AbstractPipelineStepRepository, IPipelineStepRepository
	{
		public PipelineStepRepository(
			ILogger<PipelineStepRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>25015742852e386e61f2cb6002621952</Hash>
</Codenesium>*/