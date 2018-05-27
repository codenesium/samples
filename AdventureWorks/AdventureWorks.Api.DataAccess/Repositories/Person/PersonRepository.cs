using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PersonRepository: AbstractPersonRepository, IPersonRepository
	{
		public PersonRepository(
			IDALPersonMapper mapper,
			ILogger<PersonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>6239a4cf40f82a7d93fcea865cb2dabd</Hash>
</Codenesium>*/