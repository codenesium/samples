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
	public class BOPersonPhone: AbstractBOPersonPhone, IBOPersonPhone
	{
		public BOPersonPhone(
			ILogger<PersonPhoneRepository> logger,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator)
			: base(logger, personPhoneRepository, personPhoneModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a2deb74d4357b2e3f2e4306d8ad61dea</Hash>
</Codenesium>*/