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
			IApiPersonPhoneModelValidator personPhoneModelValidator)
			: base(logger, personPhoneRepository, personPhoneModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>616d965ef19c7bba34c433ab79cd94de</Hash>
</Codenesium>*/