using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class StoreService : AbstractStoreService, IStoreService
	{
		public StoreService(
			ILogger<IStoreRepository> logger,
			IStoreRepository storeRepository,
			IApiStoreRequestModelValidator storeModelValidator,
			IBOLStoreMapper bolstoreMapper,
			IDALStoreMapper dalstoreMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base(logger,
			       storeRepository,
			       storeModelValidator,
			       bolstoreMapper,
			       dalstoreMapper,
			       bolCustomerMapper,
			       dalCustomerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>13f194e44c27e67f8fd7925c12716a9e</Hash>
</Codenesium>*/