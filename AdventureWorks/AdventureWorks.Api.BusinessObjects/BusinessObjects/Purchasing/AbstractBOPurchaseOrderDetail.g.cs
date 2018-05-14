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
		private IApiPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator;
		private ILogger logger;

		public AbstractBOPurchaseOrderDetail(
			ILogger logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator)

		{
			this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPurchaseOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderDetailRepository.All(skip, take, orderClause);
		}

		public virtual POCOPurchaseOrderDetail Get(int purchaseOrderID)
		{
			return this.purchaseOrderDetailRepository.Get(purchaseOrderID);
		}

		public virtual async Task<CreateResponse<POCOPurchaseOrderDetail>> Create(
			ApiPurchaseOrderDetailModel model)
		{
			CreateResponse<POCOPurchaseOrderDetail> response = new CreateResponse<POCOPurchaseOrderDetail>(await this.purchaseOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPurchaseOrderDetail record = this.purchaseOrderDetailRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			ApiPurchaseOrderDetailModel model)
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

		public List<POCOPurchaseOrderDetail> GetProductID(int productID)
		{
			return this.purchaseOrderDetailRepository.GetProductID(productID);
		}
	}
}

/*<Codenesium>
    <Hash>838727663f897494a6e90fd586af0932</Hash>
</Codenesium>*/