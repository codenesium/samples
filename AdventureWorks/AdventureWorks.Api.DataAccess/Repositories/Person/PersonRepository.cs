using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PersonRepository: AbstractPersonRepository, IPersonRepository
	{
		public PersonRepository(
			ILogger<PersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>0d76d20bddab12d31bcc7fd3a20b7e63</Hash>
</Codenesium>*/