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
			IWorkOrderModelValidator workOrderModelValidator)
			: base(logger, workOrderRepository, workOrderModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>5038d179a033187d50f879139a1d612a</Hash>
</Codenesium>*/