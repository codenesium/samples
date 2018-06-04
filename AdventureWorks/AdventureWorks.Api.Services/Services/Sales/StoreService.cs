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
	public class StoreService: AbstractStoreService, IStoreService
	{
		public StoreService(
			ILogger<StoreRepository> logger,
			IStoreRepository storeRepository,
			IApiStoreRequestModelValidator storeModelValidator,
			IBOLStoreMapper BOLstoreMapper,
			IDALStoreMapper DALstoreMapper)
			: base(logger, storeRepository,
			       storeModelValidator,
			       BOLstoreMapper,
			       DALstoreMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>3f29be5fea18cefd7229a33590479796</Hash>
</Codenesium>*/