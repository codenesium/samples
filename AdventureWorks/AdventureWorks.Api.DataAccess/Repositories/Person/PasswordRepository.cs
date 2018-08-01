using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PasswordRepository : AbstractPasswordRepository, IPasswordRepository
	{
		public PasswordRepository(
			ILogger<PasswordRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b55cfc8038d2d17cf94712b58e27b69d</Hash>
</Codenesium>*/