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
    <Hash>491631e0ea92bec59dd860043e378d68</Hash>
</Codenesium>*/