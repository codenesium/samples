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
	public class EmailAddressService: AbstractEmailAddressService, IEmailAddressService
	{
		public EmailAddressService(
			ILogger<EmailAddressRepository> logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper BOLemailAddressMapper,
			IDALEmailAddressMapper DALemailAddressMapper)
			: base(logger, emailAddressRepository,
			       emailAddressModelValidator,
			       BOLemailAddressMapper,
			       DALemailAddressMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ca6787f5cffc932b45219a5d29ea9f6c</Hash>
</Codenesium>*/