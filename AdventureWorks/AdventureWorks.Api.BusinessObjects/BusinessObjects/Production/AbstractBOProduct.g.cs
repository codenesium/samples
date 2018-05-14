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
		private IApiProductModelValidator productModelValidator;
		private ILogger logger;

		public AbstractBOProduct(
			ILogger logger,
			IProductRepository productRepository,
			IApiProductModelValidator productModelValidator)

		{
			this.productRepository = productRepository;
			this.productModelValidator = productModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productRepository.All(skip, take, orderClause);
		}

		public virtual POCOProduct Get(int productID)
		{
			return this.productRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProduct>> Create(
			ApiProductModel model)
		{
			CreateResponse<POCOProduct> response = new CreateResponse<POCOProduct>(await this.productModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProduct record = this.productRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductModel model)
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

		public POCOProduct GetName(string name)
		{
			return this.productRepository.GetName(name);
		}

		public POCOProduct GetProductNumber(string productNumber)
		{
			return this.productRepository.GetProductNumber(productNumber);
		}
	}
}

/*<Codenesium>
    <Hash>38db53d2c566c123ef63b0d9c3945864</Hash>
</Codenesium>*/