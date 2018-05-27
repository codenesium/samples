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
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper passwordMapper)
			: base(logger, passwordRepository, passwordModelValidator, passwordMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4ea5aa44c31c6cbc9f673f0206c8a558</Hash>
</Codenesium>*/