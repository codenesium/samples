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
	public abstract class AbstractApiSpecialOfferServerRequestModelValidator : AbstractValidator<ApiSpecialOfferServerRequestModel>
	{
		private int existingRecordId;

		protected ISpecialOfferRepository SpecialOfferRepository { get; private set; }

		public AbstractApiSpecialOfferServerRequestModelValidator(ISpecialOfferRepository specialOfferRepository)
		{
			this.SpecialOfferRepository = specialOfferRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CategoryRules()
		{
			this.RuleFor(x => x.Category).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Category).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 255).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DiscountPctRules()
		{
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void MaxQtyRules()
		{
		}

		public virtual void MinQtyRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSpecialOfferServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Type).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByRowguid(ApiSpecialOfferServerRequestModel model,  CancellationToken cancellationToken)
		{
			SpecialOffer record = await this.SpecialOfferRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.SpecialOfferID == this.existingRecordId))
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
    <Hash>bed31a95f470f900e5c8231f8f02af48</Hash>
</Codenesium>*/