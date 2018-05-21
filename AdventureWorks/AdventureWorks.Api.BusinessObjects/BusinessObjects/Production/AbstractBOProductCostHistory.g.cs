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
	public abstract class AbstractBOProductCostHistory: AbstractBOManager
	{
		private IProductCostHistoryRepository productCostHistoryRepository;
		private IApiProductCostHistoryModelValidator productCostHistoryModelValidator;
		private ILogger logger;

		public AbstractBOProductCostHistory(
			ILogger logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IApiProductCostHistoryModelValidator productCostHistoryModelValidator)
			: base()

		{
			this.productCostHistoryRepository = productCostHistoryRepository;
			this.productCostHistoryModelValidator = productCostHistoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductCostHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCostHistoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductCostHistory> Get(int productID)
		{
			return this.productCostHistoryRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductCostHistory>> Create(
			ApiProductCostHistoryModel model)
		{
			CreateResponse<POCOProductCostHistory> response = new CreateResponse<POCOProductCostHistory>(await this.productCostHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductCostHistory record = await this.productCostHistoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductCostHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				await this.productCostHistoryRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productCostHistoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a807d9099fc3c8a83f54f434be35588a</Hash>
</Codenesium>*/