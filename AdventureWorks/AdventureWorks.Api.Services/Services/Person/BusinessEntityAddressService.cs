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
	public class BusinessEntityAddressService: AbstractBusinessEntityAddressService, IBusinessEntityAddressService
	{
		public BusinessEntityAddressService(
			ILogger<BusinessEntityAddressRepository> logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
			IBOLBusinessEntityAddressMapper BOLbusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper DALbusinessEntityAddressMapper)
			: base(logger, businessEntityAddressRepository,
			       businessEntityAddressModelValidator,
			       BOLbusinessEntityAddressMapper,
			       DALbusinessEntityAddressMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>d80c56d49953176a761dd27b48f24ac7</Hash>
</Codenesium>*/