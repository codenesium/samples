using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class RowVersionCheckRepository : AbstractRowVersionCheckRepository, IRowVersionCheckRepository
	{
		public RowVersionCheckRepository(
			ILogger<RowVersionCheckRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4dedccba00bef5d3756f4d03f3cd4a3c</Hash>
</Codenesium>*/