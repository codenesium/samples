using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class EmailAddressRepository: AbstractEmailAddressRepository, IEmailAddressRepository
	{
		public EmailAddressRepository(
			IDALEmailAddressMapper mapper,
			ILogger<EmailAddressRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e541b84a8822a4841539175b8a0c05fb</Hash>
</Codenesium>*/