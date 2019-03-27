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
	public abstract class AbstractApiProductServerRequestModelValidator : AbstractValidator<ApiProductServerRequestModel>
	{
		private int existingRecordId;

		protected IProductRepository ProductRepository { get; private set; }

		public AbstractApiProductServerRequestModelValidator(IProductRepository productRepository)
		{
			this.ProductRepository = productRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>5cc09018a95ed6a77ce917cb1bb014ae</Hash>
</Codenesium>*/