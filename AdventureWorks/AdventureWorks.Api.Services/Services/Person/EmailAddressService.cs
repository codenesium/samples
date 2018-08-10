using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class EmailAddressService : AbstractEmailAddressService, IEmailAddressService
	{
		public EmailAddressService(
			ILogger<IEmailAddressRepository> logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressRequestModelValidator emailAddressModelValidator,
			IBOLEmailAddressMapper bolemailAddressMapper,
			IDALEmailAddressMapper dalemailAddressMapper
			)
			: base(logger,
			       emailAddressRepository,
			       emailAddressModelValidator,
			       bolemailAddressMapper,
			       dalemailAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4fc4b8e8487367122ca689a8ef800a05</Hash>
</Codenesium>*/