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
		private IApiSalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderHeaderSalesReason(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator)

		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderSalesReasonRepository.All(skip, take, orderClause);
		}

		public virtual POCOSalesOrderHeaderSalesReason Get(int salesOrderID)
		{
			return this.salesOrderHeaderSalesReasonRepository.Get(salesOrderID);
		}

		public virtual async Task<CreateResponse<POCOSalesOrderHeaderSalesReason>> Create(
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			CreateResponse<POCOSalesOrderHeaderSalesReason> response = new CreateResponse<POCOSalesOrderHeaderSalesReason>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesOrderHeaderSalesReason record = this.salesOrderHeaderSalesReasonRepository.Create(model);
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
	}
}

/*<Codenesium>
    <Hash>f081f614f42d05b13dd78cf79d48a032</Hash>
</Codenesium>*/