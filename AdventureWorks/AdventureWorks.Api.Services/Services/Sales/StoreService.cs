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
			IDALCustomerMapper dalCustomerMapper
			)
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
    <Hash>be1324525750d6bda1ec920ecfbd3db4</Hash>
</Codenesium>*/