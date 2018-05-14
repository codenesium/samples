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
			IApiSalesPersonModelValidator salesPersonModelValidator)
			: base(logger, salesPersonRepository, salesPersonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>97013d2c35e15e5618f17f2f92675649</Hash>
</Codenesium>*/