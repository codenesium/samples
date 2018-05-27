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
			IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
			IBOLBusinessEntityAddressMapper businessEntityAddressMapper)
			: base(logger, businessEntityAddressRepository, businessEntityAddressModelValidator, businessEntityAddressMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4c0be633db235e96b9d8cf62e8492759</Hash>
</Codenesium>*/