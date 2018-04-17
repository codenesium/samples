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
	public class BOPassword: AbstractBOPassword, IBOPassword
	{
		public BOPassword(
			ILogger<PasswordRepository> logger,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator)
			: base(logger, passwordRepository, passwordModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7ccae4e8a62a45fd1aed632e021a8b18</Hash>
</Codenesium>*/