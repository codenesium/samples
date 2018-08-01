using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class EmailAddressRepository : AbstractEmailAddressRepository, IEmailAddressRepository
	{
		public EmailAddressRepository(
			ILogger<EmailAddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>591f7e2e310981d59e5558396d7ac8f4</Hash>
</Codenesium>*/