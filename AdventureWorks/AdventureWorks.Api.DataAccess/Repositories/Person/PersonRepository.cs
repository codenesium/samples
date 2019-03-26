using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PersonRepository : AbstractPersonRepository, IPersonRepository
	{
		public PersonRepository(
			ILogger<PersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e130a281b3d58660e978c2adbfd27014</Hash>
</Codenesium>*/