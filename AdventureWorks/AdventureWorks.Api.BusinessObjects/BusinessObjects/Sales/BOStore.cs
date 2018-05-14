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
			IApiStoreModelValidator storeModelValidator)
			: base(logger, storeRepository, storeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>98cf3b00d2006e8e3e3fd2081cc335bf</Hash>
</Codenesium>*/