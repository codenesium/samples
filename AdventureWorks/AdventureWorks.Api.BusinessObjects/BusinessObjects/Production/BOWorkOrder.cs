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
	public class BOWorkOrder: AbstractBOWorkOrder, IBOWorkOrder
	{
		public BOWorkOrder(
			ILogger<WorkOrderRepository> logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper workOrderMapper)
			: base(logger, workOrderRepository, workOrderModelValidator, workOrderMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c9174e7655ab924e19e28b407ab652fb</Hash>
</Codenesium>*/