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
	public abstract class AbstractBOProductListPriceHistory
	{
		private IProductListPriceHistoryRepository productListPriceHistoryRepository;
		private IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator;
		private ILogger logger;

		public AbstractBOProductListPriceHistory(
			ILogger logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator)

		{
			this.productListPriceHistoryRepository = productListPriceHistoryRepository;
			this.productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductListPriceHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productListPriceHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productListPriceHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductListPriceHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productListPriceHistoryRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productListPriceHistoryRepository.Delete(productID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.productListPriceHistoryRepository.GetById(productID);
		}

		public virtual POCOProductListPriceHistory GetByIdDirect(int productID)
		{
			return this.productListPriceHistoryRepository.GetByIdDirect(productID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productListPriceHistoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productListPriceHistoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductListPriceHistory> GetWhereDirect(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productListPriceHistoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>b12e8070b9f1b782804d6defd10d4337</Hash>
</Codenesium>*/