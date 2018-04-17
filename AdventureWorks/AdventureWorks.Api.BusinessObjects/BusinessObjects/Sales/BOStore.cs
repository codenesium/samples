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
	public class BOStore: AbstractBOStore, IBOStore
	{
		public BOStore(
			ILogger<StoreRepository> logger,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator)
			: base(logger, storeRepository, storeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>24ee835a7585da92ce56f00b4b80b3aa</Hash>
</Codenesium>*/