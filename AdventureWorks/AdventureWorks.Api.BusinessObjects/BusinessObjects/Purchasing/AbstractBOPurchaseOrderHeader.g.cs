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
	public abstract class AbstractBOPurchaseOrderHeader
	{
		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;
		private IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator;
		private ILogger logger;

		public AbstractBOPurchaseOrderHeader(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator)

		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PurchaseOrderHeaderModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.purchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.purchaseOrderHeaderRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model));

			if (response.Success)
			{
				this.purchaseOrderHeaderRepository.Update(purchaseOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				this.purchaseOrderHeaderRepository.Delete(purchaseOrderID);
			}
			return response;
		}

		public virtual POCOPurchaseOrderHeader Get(int purchaseOrderID)
		{
			return this.purchaseOrderHeaderRepository.Get(purchaseOrderID);
		}

		public virtual List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderHeaderRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>7b9ac4a11e0b5fe6773c3a5ba9515211</Hash>
</Codenesium>*/