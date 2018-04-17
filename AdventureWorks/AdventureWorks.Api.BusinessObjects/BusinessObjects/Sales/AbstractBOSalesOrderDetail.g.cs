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
	public abstract class AbstractBOSalesOrderDetail
	{
		private ISalesOrderDetailRepository salesOrderDetailRepository;
		private ISalesOrderDetailModelValidator salesOrderDetailModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderDetail(
			ILogger logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			ISalesOrderDetailModelValidator salesOrderDetailModelValidator)

		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
			this.salesOrderDetailModelValidator = salesOrderDetailModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesOrderDetailModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesOrderDetailRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			SalesOrderDetailModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				this.salesOrderDetailRepository.Update(salesOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				this.salesOrderDetailRepository.Delete(salesOrderID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int salesOrderID)
		{
			return this.salesOrderDetailRepository.GetById(salesOrderID);
		}

		public virtual POCOSalesOrderDetail GetByIdDirect(int salesOrderID)
		{
			return this.salesOrderDetailRepository.GetByIdDirect(salesOrderID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderDetailRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderDetailRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesOrderDetail> GetWhereDirect(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderDetailRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>5ee7c08cc0fc7f7a97025e0f19ea9e65</Hash>
</Codenesium>*/