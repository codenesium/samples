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
	public abstract class AbstractBOProductCategory: AbstractBOManager
	{
		private IProductCategoryRepository productCategoryRepository;
		private IApiProductCategoryModelValidator productCategoryModelValidator;
		private ILogger logger;

		public AbstractBOProductCategory(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryModelValidator productCategoryModelValidator)
			: base()

		{
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCategoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductCategory> Get(int productCategoryID)
		{
			return this.productCategoryRepository.Get(productCategoryID);
		}

		public virtual async Task<CreateResponse<POCOProductCategory>> Create(
			ApiProductCategoryModel model)
		{
			CreateResponse<POCOProductCategory> response = new CreateResponse<POCOProductCategory>(await this.productCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductCategory record = await this.productCategoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productCategoryID,
			ApiProductCategoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productCategoryModelValidator.ValidateUpdateAsync(productCategoryID, model));

			if (response.Success)
			{
				await this.productCategoryRepository.Update(productCategoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productCategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productCategoryModelValidator.ValidateDeleteAsync(productCategoryID));

			if (response.Success)
			{
				await this.productCategoryRepository.Delete(productCategoryID);
			}
			return response;
		}

		public async Task<POCOProductCategory> GetName(string name)
		{
			return await this.productCategoryRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>5c633037ddb3ea2d683cac5bc9a35d53</Hash>
</Codenesium>*/