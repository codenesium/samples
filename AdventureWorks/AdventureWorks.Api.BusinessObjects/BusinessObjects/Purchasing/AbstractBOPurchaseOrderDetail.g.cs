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

		public virtual POCOPurchaseOrderDetail Get(int purchaseOrderID)
		{
			return this.purchaseOrderDetailRepository.Get(purchaseOrderID);
		}

		public virtual List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderDetailRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>9b343db23ac6ab8e05add87ec0950974</Hash>
</Codenesium>*/