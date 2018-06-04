using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class PersonService: AbstractPersonService, IPersonService
	{
		public PersonService(
			ILogger<PersonRepository> logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper BOLpersonMapper,
			IDALPersonMapper DALpersonMapper)
			: base(logger, personRepository,
			       personModelValidator,
			       BOLpersonMapper,
			       DALpersonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e93b8446f04cfeee7c1909a3f64feb2b</Hash>
</Codenesium>*/