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
			IApiPersonModelValidator personModelValidator)
			: base(logger, personRepository, personModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>be2a0b69d4c52b2012f8b4fdf5da9b50</Hash>
</Codenesium>*/