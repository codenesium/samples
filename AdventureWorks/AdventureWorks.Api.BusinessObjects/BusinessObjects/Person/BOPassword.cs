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
			IApiPasswordModelValidator passwordModelValidator)
			: base(logger, passwordRepository, passwordModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>733c69642788b359d52b7df30c1b95c3</Hash>
</Codenesium>*/