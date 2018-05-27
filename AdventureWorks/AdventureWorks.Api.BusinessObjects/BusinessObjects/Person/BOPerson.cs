using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOPerson: AbstractBOPerson, IBOPerson
	{
		public BOPerson(
			ILogger<PersonRepository> logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper personMapper)
			: base(logger, personRepository, personModelValidator, personMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>53fd2416d7d52682e4ae5a87b27e916f</Hash>
</Codenesium>*/