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
	public abstract class AbstractBOProductCategory
	{
		private IProductCategoryRepository productCategoryRepository;
		private IApiProductCategoryModelValidator productCategoryModelValidator;
		private ILogger logger;

		public AbstractBOProductCategory(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryModelValidator productCategoryModelValidator)

		{
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductCategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCategoryRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductCategory Get(int productCategoryID)
		{
			return this.productCategoryRepository.Get(productCategoryID);
		}

		public virtual async Task<CreateResponse<POCOProductCategory>> Create(
			ApiProductCategoryModel model)
		{
			CreateResponse<POCOProductCategory> response = new CreateResponse<POCOProductCategory>(await this.productCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductCategory record = this.productCategoryRepository.Create(model);
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
				this.productCategoryRepository.Update(productCategoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productCategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productCategoryModelValidator.ValidateDeleteAsync(productCategoryID));

			if (response.Success)
			{
				this.productCategoryRepository.Delete(productCategoryID);
			}
			return response;
		}

		public POCOProductCategory GetName(string name)
		{
			return this.productCategoryRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>5352922818ad409612617de9abc53595</Hash>
</Codenesium>*/