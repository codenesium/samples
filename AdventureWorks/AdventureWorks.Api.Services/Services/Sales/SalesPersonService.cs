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
	public class SalesPersonService: AbstractSalesPersonService, ISalesPersonService
	{
		public SalesPersonService(
			ILogger<SalesPersonRepository> logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper BOLsalesPersonMapper,
			IDALSalesPersonMapper DALsalesPersonMapper)
			: base(logger, salesPersonRepository,
			       salesPersonModelValidator,
			       BOLsalesPersonMapper,
			       DALsalesPersonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a53acb93be18b41aa5f157ce853b78e4</Hash>
</Codenesium>*/