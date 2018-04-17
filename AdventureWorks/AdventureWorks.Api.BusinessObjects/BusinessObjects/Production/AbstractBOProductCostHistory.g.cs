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
	public abstract class AbstractBOProductCostHistory
	{
		private IProductCostHistoryRepository productCostHistoryRepository;
		private IProductCostHistoryModelValidator productCostHistoryModelValidator;
		private ILogger logger;

		public AbstractBOProductCostHistory(
			ILogger logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator)

		{
			this.productCostHistoryRepository = productCostHistoryRepository;
			this.productCostHistoryModelValidator = productCostHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductCostHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productCostHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productCostHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductCostHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productCostHistoryRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productCostHistoryRepository.Delete(productID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.productCostHistoryRepository.GetById(productID);
		}

		public virtual POCOProductCostHistory GetByIdDirect(int productID)
		{
			return this.productCostHistoryRepository.GetByIdDirect(productID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCostHistoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCostHistoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCostHistoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>36b909c6d943df8d31d7c693f0876132</Hash>
</Codenesium>*/