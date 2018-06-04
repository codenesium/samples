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
	public class PersonPhoneService: AbstractPersonPhoneService, IPersonPhoneService
	{
		public PersonPhoneService(
			ILogger<PersonPhoneRepository> logger,
			IPersonPhoneRepository personPhoneRepository,
			IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
			IBOLPersonPhoneMapper BOLpersonPhoneMapper,
			IDALPersonPhoneMapper DALpersonPhoneMapper)
			: base(logger, personPhoneRepository,
			       personPhoneModelValidator,
			       BOLpersonPhoneMapper,
			       DALpersonPhoneMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3870df69192b87bd71394b9288622c64</Hash>
</Codenesium>*/