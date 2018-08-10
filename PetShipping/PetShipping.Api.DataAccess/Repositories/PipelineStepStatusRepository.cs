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
	public partial class PipelineStepStatusRepository : AbstractPipelineStepStatusRepository, IPipelineStepStatusRepository
	{
		public PipelineStepStatusRepository(
			ILogger<PipelineStepStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>25903e78e32e5426e44cacd457444fdc</Hash>
</Codenesium>*/