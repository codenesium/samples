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
    <Hash>cac1bf03b5ee0ce51aab3ecbb8965a9a</Hash>
</Codenesium>*/