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
	public abstract class AbstractBOProductListPriceHistory: AbstractBOManager
	{
		private IProductListPriceHistoryRepository productListPriceHistoryRepository;
		private IApiProductListPriceHistoryModelValidator productListPriceHistoryModelValidator;
		private ILogger logger;

		public AbstractBOProductListPriceHistory(
			ILogger logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IApiProductListPriceHistoryModelValidator productListPriceHistoryModelValidator)
			: base()

		{
			this.productListPriceHistoryRepository = productListPriceHistoryRepository;
			this.productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productListPriceHistoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductListPriceHistory> Get(int productID)
		{
			return this.productListPriceHistoryRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductListPriceHistory>> Create(
			ApiProductListPriceHistoryModel model)
		{
			CreateResponse<POCOProductListPriceHistory> response = new CreateResponse<POCOProductListPriceHistory>(await this.productListPriceHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductListPriceHistory record = await this.productListPriceHistoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductListPriceHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				await this.productListPriceHistoryRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productListPriceHistoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9318faa7364495311f6d109c9ee7b891</Hash>
</Codenesium>*/