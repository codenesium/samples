using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiProductServerRequestModelValidator : AbstractValidator<ApiProductServerRequestModel>, IApiProductServerRequestModelValidator
	{
		private int existingRecordId;

		protected IProductRepository ProductRepository { get; private set; }

		public ApiProductServerRequestModelValidator(IProductRepository productRepository)
		{
			this.ProductRepository = productRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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

		public virtual void ActiveRules()
		{
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 4096).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PriceRules()
		{
		}

		public virtual void QuantityRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>76771f3882571dff7aad9b1786966f00</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/