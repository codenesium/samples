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

		protected IProductModelRepository ProductModelRepository { get; private set; }

		public AbstractApiProductModelServerRequestModelValidator(IProductModelRepository productModelRepository)
		{
			this.ProductModelRepository = productModelRepository;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByName(ApiProductModelServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.ProductModelRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductModelID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiProductModelServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.ProductModelRepository.ByRowguid(model.Rowguid);

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
    <Hash>f7c0ee67cc587d80cf8895f59df5e51c</Hash>
</Codenesium>*/