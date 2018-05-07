using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOSalesOrderHeaderSalesReason
	{
		private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;
		private ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderHeaderSalesReason(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator)

		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesOrderHeaderSalesReasonModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesOrderHeaderSalesReasonRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			SalesOrderHeaderSalesReasonModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				this.salesOrderHeaderSalesReasonRepository.Update(salesOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				this.salesOrderHeaderSalesReasonRepository.Delete(salesOrderID);
			}
			return response;
		}

		public virtual POCOSalesOrderHeaderSalesReason Get(int salesOrderID)
		{
			return this.salesOrderHeaderSalesReasonRepository.Get(salesOrderID);
		}

		public virtual List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderSalesReasonRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>53b6fa847914f6eb402d8d925b026c18</Hash>
</Codenesium>*/