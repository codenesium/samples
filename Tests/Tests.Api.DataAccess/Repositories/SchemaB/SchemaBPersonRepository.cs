using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
	public partial class SchemaBPersonRepository : AbstractSchemaBPersonRepository, ISchemaBPersonRepository
	{
		public SchemaBPersonRepository(
			ILogger<SchemaBPersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>212e069c755d5c147e7e8379420b87bc</Hash>
</Codenesium>*/