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

		public virtual POCOProduct Get(int productID)
		{
			return this.productRepository.Get(productID);
		}

		public virtual List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c95dd2a31862df390fd88cb85da00dbd</Hash>
</Codenesium>*/