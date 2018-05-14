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
			IApiEmailAddressModelValidator emailAddressModelValidator)
			: base(logger, emailAddressRepository, emailAddressModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2d7ca245525aff82a7caf73c2b4d34e7</Hash>
</Codenesium>*/