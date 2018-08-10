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
    <Hash>e9168cb2f96a381b2f0bb9efc7de588d</Hash>
</Codenesium>*/