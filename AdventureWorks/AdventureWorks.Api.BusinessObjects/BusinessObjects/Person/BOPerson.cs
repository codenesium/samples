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
			IPersonModelValidator personModelValidator)
			: base(logger, personRepository, personModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8f63fa2b3b12333c5c5d8c6e72d19980</Hash>
</Codenesium>*/