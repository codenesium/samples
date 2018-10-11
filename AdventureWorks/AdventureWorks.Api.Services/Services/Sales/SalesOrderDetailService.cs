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
	public partial class SalesOrderDetailService : AbstractSalesOrderDetailService, ISalesOrderDetailService
	{
		public SalesOrderDetailService(
			ILogger<ISalesOrderDetailRepository> logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper bolsalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalsalesOrderDetailMapper)
			: base(logger,
			       salesOrderDetailRepository,
			       salesOrderDetailModelValidator,
			       bolsalesOrderDetailMapper,
			       dalsalesOrderDetailMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e46cffb0354cb6703f722aa27a5441f2</Hash>
</Codenesium>*/