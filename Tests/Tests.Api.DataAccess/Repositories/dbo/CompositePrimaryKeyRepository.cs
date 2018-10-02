using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial class CompositePrimaryKeyRepository : AbstractCompositePrimaryKeyRepository, ICompositePrimaryKeyRepository
	{
		public CompositePrimaryKeyRepository(
			ILogger<CompositePrimaryKeyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d8519a6b4b99ee4242bb7d2d8c2b9d05</Hash>
</Codenesium>*/