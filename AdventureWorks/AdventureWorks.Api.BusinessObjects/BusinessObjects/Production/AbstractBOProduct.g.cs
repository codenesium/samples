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
	public abstract class AbstractBOProduct
	{
		private IProductRepository productRepository;
		private IProductModelValidator productModelValidator;
		private ILogger logger;

		public AbstractBOProduct(
			ILogger logger,
			IProductRepository productRepository,
			IProductModelValidator productModelValidator)

		{
			this.productRepository = productRepository;
			this.productModelValidator = productModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productRepository.Delete(productID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.productRepository.GetById(productID);
		}

		public virtual POCOProduct GetByIdDirect(int productID)
		{
			return this.productRepository.GetByIdDirect(productID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProduct> GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>3fcbbe110ae25f8ac5c0006012818968</Hash>
</Codenesium>*/