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
			IApiStoreRequestModelValidator storeModelValidator,
			IBOLStoreMapper storeMapper)
			: base(logger, storeRepository, storeModelValidator, storeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>447a3e6f99f732fdc6240f103aa044da</Hash>
</Codenesium>*/