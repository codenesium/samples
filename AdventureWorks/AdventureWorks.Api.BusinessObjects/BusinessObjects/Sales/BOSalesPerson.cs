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
			ISalesPersonModelValidator salesPersonModelValidator)
			: base(logger, salesPersonRepository, salesPersonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2ab726641985d69d4138e7869639559c</Hash>
</Codenesium>*/