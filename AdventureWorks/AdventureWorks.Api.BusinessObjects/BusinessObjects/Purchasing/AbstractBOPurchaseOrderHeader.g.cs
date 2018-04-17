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

		public virtual ApiResponse GetById(int purchaseOrderID)
		{
			return this.purchaseOrderHeaderRepository.GetById(purchaseOrderID);
		}

		public virtual POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID)
		{
			return this.purchaseOrderHeaderRepository.GetByIdDirect(purchaseOrderID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderHeaderRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderHeaderRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderHeaderRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2708e8fd1a8f9bc5026810f58a933b78</Hash>
</Codenesium>*/