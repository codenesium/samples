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
	public class BusinessEntityService: AbstractBusinessEntityService, IBusinessEntityService
	{
		public BusinessEntityService(
			ILogger<BusinessEntityRepository> logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper BOLbusinessEntityMapper,
			IDALBusinessEntityMapper DALbusinessEntityMapper)
			: base(logger, businessEntityRepository,
			       businessEntityModelValidator,
			       BOLbusinessEntityMapper,
			       DALbusinessEntityMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b65b0154e73e1475d442663525e2e274</Hash>
</Codenesium>*/