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
			IObjectMapper mapper,
			ILogger<PersonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>26f8ebf65ed2c1632b89c7cfd4d41823</Hash>
</Codenesium>*/