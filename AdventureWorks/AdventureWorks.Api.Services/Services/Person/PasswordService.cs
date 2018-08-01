using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class PasswordService : AbstractPasswordService, IPasswordService
	{
		public PasswordService(
			ILogger<IPasswordRepository> logger,
			IPasswordRepository passwordRepository,
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolpasswordMapper,
			IDALPasswordMapper dalpasswordMapper
			)
			: base(logger,
			       passwordRepository,
			       passwordModelValidator,
			       bolpasswordMapper,
			       dalpasswordMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>78b7bd7c89c6e1962392dc05fa8997d6</Hash>
</Codenesium>*/