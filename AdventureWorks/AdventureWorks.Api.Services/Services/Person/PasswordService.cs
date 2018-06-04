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
	public class PasswordService: AbstractPasswordService, IPasswordService
	{
		public PasswordService(
			ILogger<PasswordRepository> logger,
			IPasswordRepository passwordRepository,
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper BOLpasswordMapper,
			IDALPasswordMapper DALpasswordMapper)
			: base(logger, passwordRepository,
			       passwordModelValidator,
			       BOLpasswordMapper,
			       DALpasswordMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ef5e6215a7ad1aff9302fa84648b0094</Hash>
</Codenesium>*/