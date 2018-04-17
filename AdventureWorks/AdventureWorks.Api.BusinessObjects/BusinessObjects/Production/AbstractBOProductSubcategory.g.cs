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
	public abstract class AbstractBOProductSubcategory
	{
		private IProductSubcategoryRepository productSubcategoryRepository;
		private IProductSubcategoryModelValidator productSubcategoryModelValidator;
		private ILogger logger;

		public AbstractBOProductSubcategory(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IProductSubcategoryModelValidator productSubcategoryModelValidator)

		{
			this.productSubcategoryRepository = productSubcategoryRepository;
			this.productSubcategoryModelValidator = productSubcategoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductSubcategoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productSubcategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productSubcategoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productSubcategoryID,
			ProductSubcategoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model));

			if (response.Success)
			{
				this.productSubcategoryRepository.Update(productSubcategoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				this.productSubcategoryRepository.Delete(productSubcategoryID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int productSubcategoryID)
		{
			return this.productSubcategoryRepository.GetById(productSubcategoryID);
		}

		public virtual POCOProductSubcategory GetByIdDirect(int productSubcategoryID)
		{
			return this.productSubcategoryRepository.GetByIdDirect(productSubcategoryID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productSubcategoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productSubcategoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productSubcategoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8f7b77eddd26ee6b72b8797f90bc287b</Hash>
</Codenesium>*/