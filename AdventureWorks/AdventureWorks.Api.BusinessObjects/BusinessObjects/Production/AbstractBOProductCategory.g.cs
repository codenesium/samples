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
		private IProductCategoryModelValidator productCategoryModelValidator;
		private ILogger logger;

		public AbstractBOProductCategory(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IProductCategoryModelValidator productCategoryModelValidator)

		{
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductCategoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productCategoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productCategoryID,
			ProductCategoryModel model)
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

		public virtual ApiResponse GetById(int productCategoryID)
		{
			return this.productCategoryRepository.GetById(productCategoryID);
		}

		public virtual POCOProductCategory GetByIdDirect(int productCategoryID)
		{
			return this.productCategoryRepository.GetByIdDirect(productCategoryID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCategoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCategoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productCategoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>f321c1b46af24c1f9a3f27ec1cc83d16</Hash>
</Codenesium>*/