using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class CultureRepository : AbstractCultureRepository, ICultureRepository
	{
		public CultureRepository(
			ILogger<CultureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c3b296384da97c16fc6248e70d86a49a</Hash>
</Codenesium>*/