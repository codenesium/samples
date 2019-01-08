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
	public partial class IncludedColumnTestRepository : AbstractIncludedColumnTestRepository, IIncludedColumnTestRepository
	{
		public IncludedColumnTestRepository(
			ILogger<IncludedColumnTestRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>93513a70ce8e60ad874ff8f09b0798f1</Hash>
</Codenesium>*/