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
	public abstract class AbstractApiProductDescriptionServerRequestModelValidator : AbstractValidator<ApiProductDescriptionServerRequestModel>
	{
		private int existingRecordId;

		protected IProductDescriptionRepository ProductDescriptionRepository { get; private set; }

		public AbstractApiProductDescriptionServerRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
		{
			this.ProductDescriptionRepository = productDescriptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductDescriptionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 400).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiProductDescriptionServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByRowguid(ApiProductDescriptionServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductDescription record = await this.ProductDescriptionRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductDescriptionID == this.existingRecordId))
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
    <Hash>9c93abec338d48c53d19a315a921c893</Hash>
</Codenesium>*/