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
	public class BOEmailAddress: AbstractBOEmailAddress, IBOEmailAddress
	{
		public BOEmailAddress(
			ILogger<EmailAddressRepository> logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper emailAddressMapper)
			: base(logger, emailAddressRepository, emailAddressModelValidator, emailAddressMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>70b37df754cbf6d71149e1513e0ae96a</Hash>
</Codenesium>*/