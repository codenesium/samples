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
			IEmailAddressModelValidator emailAddressModelValidator)
			: base(logger, emailAddressRepository, emailAddressModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>45dad908f3728822dfecc4912481b687</Hash>
</Codenesium>*/