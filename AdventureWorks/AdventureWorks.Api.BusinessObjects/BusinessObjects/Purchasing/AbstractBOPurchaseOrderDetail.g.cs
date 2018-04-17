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
	public abstract class AbstractBOPurchaseOrderDetail
	{
		private IPurchaseOrderDetailRepository purchaseOrderDetailRepository;
		private IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator;
		private ILogger logger;

		public AbstractBOPurchaseOrderDetail(
			ILogger logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator)

		{
			this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PurchaseOrderDetailModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.purchaseOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.purchaseOrderDetailRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			PurchaseOrderDetailModel model)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderDetailModelValidator.ValidateUpdateAsync(purchaseOrderID, model));

			if (response.Success)
			{
				this.purchaseOrderDetailRepository.Update(purchaseOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderDetailModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				this.purchaseOrderDetailRepository.Delete(purchaseOrderID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int purchaseOrderID)
		{
			return this.purchaseOrderDetailRepository.GetById(purchaseOrderID);
		}

		public virtual POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID)
		{
			return this.purchaseOrderDetailRepository.GetByIdDirect(purchaseOrderID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderDetailRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderDetailRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderDetailRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>cf13249ce25f87a4ef3d4d34343f40b2</Hash>
</Codenesium>*/