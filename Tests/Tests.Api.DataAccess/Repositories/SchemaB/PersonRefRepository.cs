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
	public partial class PersonRefRepository : AbstractPersonRefRepository, IPersonRefRepository
	{
		public PersonRefRepository(
			ILogger<PersonRefRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f7af32d3cf0bf65a19ffee08c0175e21</Hash>
</Codenesium>*/