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
	public partial class SalesReasonService : AbstractSalesReasonService, ISalesReasonService
	{
		public SalesReasonService(
			ILogger<ISalesReasonRepository> logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper bolsalesReasonMapper,
			IDALSalesReasonMapper dalsalesReasonMapper)
			: base(logger,
			       salesReasonRepository,
			       salesReasonModelValidator,
			       bolsalesReasonMapper,
			       dalsalesReasonMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a31092fb0b4afb8258a1fcd0ecfb0615</Hash>
</Codenesium>*/