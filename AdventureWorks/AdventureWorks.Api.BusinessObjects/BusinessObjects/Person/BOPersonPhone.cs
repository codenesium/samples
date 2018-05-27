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
			IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
			IBOLPersonPhoneMapper personPhoneMapper)
			: base(logger, personPhoneRepository, personPhoneModelValidator, personPhoneMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8f32eba1f733fdde432b5d350a68a8a5</Hash>
</Codenesium>*/