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

		public virtual POCOProductListPriceHistory Get(int productID)
		{
			return this.productListPriceHistoryRepository.Get(productID);
		}

		public virtual List<POCOProductListPriceHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productListPriceHistoryRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>113aa623996982260c672d516f3a9b64</Hash>
</Codenesium>*/