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
	public class BOBusinessEntityAddress: AbstractBOBusinessEntityAddress, IBOBusinessEntityAddress
	{
		public BOBusinessEntityAddress(
			ILogger<BusinessEntityAddressRepository> logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IBusinessEntityAddressModelValidator businessEntityAddressModelValidator)
			: base(logger, businessEntityAddressRepository, businessEntityAddressModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>fa01b90fbf2adca5140bc18fb75463fa</Hash>
</Codenesium>*/