using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiProductServerRequestModelValidator : AbstractApiProductServerRequestModelValidator, IApiProductServerRequestModelValidator
	{
		public ApiProductServerRequestModelValidator(IProductRepository productRepository)
			: base(productRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductServerRequestModel model)
		{
			this.ActiveRules();
			this.DescriptionRules();
			this.NameRules();
			this.PriceRules();
			this.QuantityRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductServerRequestModel model)
		{
			this.ActiveRules();
			this.DescriptionRules();
			this.NameRules();
			this.PriceRules();
			this.QuantityRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8677b4f19bcd8e8b7c0fc165fa12162e</Hash>
</Codenesium>*/