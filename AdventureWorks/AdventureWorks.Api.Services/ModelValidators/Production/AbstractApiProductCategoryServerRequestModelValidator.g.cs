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
	public abstract class AbstractApiProductCategoryServerRequestModelValidator : AbstractValidator<ApiProductCategoryServerRequestModel>
	{
		private int existingRecordId;

		protected IProductCategoryRepository ProductCategoryRepository { get; private set; }

		public AbstractApiProductCategoryServerRequestModelValidator(IProductCategoryRepository productCategoryRepository)
		{
			this.ProductCategoryRepository = productCategoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductCategoryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByName(ApiProductCategoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductCategory record = await this.ProductCategoryRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductCategoryID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiProductCategoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductCategory record = await this.ProductCategoryRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductCategoryID == this.existingRecordId))
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
    <Hash>b8691f5bee887f5a5462307520c77a7b</Hash>
</Codenesium>*/