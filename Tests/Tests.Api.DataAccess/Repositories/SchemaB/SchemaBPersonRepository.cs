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
    <Hash>7693b01b548de339939e7d56e1f5628f</Hash>
</Codenesium>*/