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
	public abstract class AbstractBOSalesOrderHeaderSalesReason: AbstractBOManager
	{
		private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;
		private IApiSalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderHeaderSalesReason(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator)
			: base()

		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderSalesReasonRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesOrderHeaderSalesReason> Get(int salesOrderID)
		{
			return this.salesOrderHeaderSalesReasonRepository.Get(salesOrderID);
		}

		public virtual async Task<CreateResponse<POCOSalesOrderHeaderSalesReason>> Create(
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			CreateResponse<POCOSalesOrderHeaderSalesReason> response = new CreateResponse<POCOSalesOrderHeaderSalesReason>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesOrderHeaderSalesReason record = await this.salesOrderHeaderSalesReasonRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				await this.salesOrderHeaderSalesReasonRepository.Update(salesOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderHeaderSalesReasonRepository.Delete(salesOrderID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>86fdd28dcb064dd30befe1a274a01d13</Hash>
</Codenesium>*/