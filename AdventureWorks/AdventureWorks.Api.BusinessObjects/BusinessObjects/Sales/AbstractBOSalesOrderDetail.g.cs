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
	public abstract class AbstractBOSalesOrderDetail: AbstractBOManager
	{
		private ISalesOrderDetailRepository salesOrderDetailRepository;
		private IApiSalesOrderDetailModelValidator salesOrderDetailModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderDetail(
			ILogger logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailModelValidator salesOrderDetailModelValidator)
			: base()

		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
			this.salesOrderDetailModelValidator = salesOrderDetailModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderDetailRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesOrderDetail> Get(int salesOrderID)
		{
			return this.salesOrderDetailRepository.Get(salesOrderID);
		}

		public virtual async Task<CreateResponse<POCOSalesOrderDetail>> Create(
			ApiSalesOrderDetailModel model)
		{
			CreateResponse<POCOSalesOrderDetail> response = new CreateResponse<POCOSalesOrderDetail>(await this.salesOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesOrderDetail record = await this.salesOrderDetailRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderDetailModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				await this.salesOrderDetailRepository.Update(salesOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderDetailRepository.Delete(salesOrderID);
			}
			return response;
		}

		public async Task<List<POCOSalesOrderDetail>> GetProductID(int productID)
		{
			return await this.salesOrderDetailRepository.GetProductID(productID);
		}
	}
}

/*<Codenesium>
    <Hash>f8eb674dd46e563580aaff6a0fa2d41e</Hash>
</Codenesium>*/