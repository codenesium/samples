using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class PasswordRepository: AbstractPasswordRepository, IPasswordRepository
	{
		public PasswordRepository(
			ILogger<PasswordRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f3139aa726b54c91da8082e102aa1397</Hash>
</Codenesium>*/