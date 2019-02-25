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
	public partial class PipelineStatusRepository : AbstractPipelineStatusRepository, IPipelineStatusRepository
	{
		public PipelineStatusRepository(
			ILogger<PipelineStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2d93cba5f512af4c9e11b32103189056</Hash>
</Codenesium>*/