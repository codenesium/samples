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
	public class BOSalesPerson: AbstractBOSalesPerson, IBOSalesPerson
	{
		public BOSalesPerson(
			ILogger<SalesPersonRepository> logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper salesPersonMapper)
			: base(logger, salesPersonRepository, salesPersonModelValidator, salesPersonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0555966c7956c3245b14d7e24efd7230</Hash>
</Codenesium>*/