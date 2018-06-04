using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class EmailAddressRepository: AbstractEmailAddressRepository, IEmailAddressRepository
	{
		public EmailAddressRepository(
			ILogger<EmailAddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>04379b6f20b0149e33218fecacf1b5d9</Hash>
</Codenesium>*/