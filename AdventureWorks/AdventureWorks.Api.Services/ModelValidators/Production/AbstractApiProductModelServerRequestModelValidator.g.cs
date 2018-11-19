using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductModelServerRequestModelValidator : AbstractValidator<ApiProductModelServerRequestModel>
	{
		private int existingRecordId;

		private IProductModelRepository productModelRepository;

		public AbstractApiProductModelServerRequestModelValidator(IProductModelRepository productModelRepository)
		{
			this.productModelRepository = productModelRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CatalogDescriptionRules()
		{
		}

		public virtual void InstructionRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		private async Task<bool> BeUniqueByName(ApiProductModelServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.productModelRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductModelID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiProductModelServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.productModelRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductModelID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e26dadfc67fafbedee1908d4d59cb07c</Hash>
</Codenesium>*/