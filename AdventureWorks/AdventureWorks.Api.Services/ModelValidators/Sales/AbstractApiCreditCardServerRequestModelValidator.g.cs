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
	public abstract class AbstractApiCreditCardServerRequestModelValidator : AbstractValidator<ApiCreditCardServerRequestModel>
	{
		private int existingRecordId;

		protected ICreditCardRepository CreditCardRepository { get; private set; }

		public AbstractApiCreditCardServerRequestModelValidator(ICreditCardRepository creditCardRepository)
		{
			this.CreditCardRepository = creditCardRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCreditCardServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CardNumberRules()
		{
			this.RuleFor(x => x.CardNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByCardNumber).When(x => (!x?.CardNumber.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiCreditCardServerRequestModel.CardNumber)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.CardNumber).Length(0, 25).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CardTypeRules()
		{
			this.RuleFor(x => x.CardType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.CardType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ExpMonthRules()
		{
		}

		public virtual void ExpYearRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		protected async Task<bool> BeUniqueByCardNumber(ApiCreditCardServerRequestModel model,  CancellationToken cancellationToken)
		{
			CreditCard record = await this.CreditCardRepository.ByCardNumber(model.CardNumber);

			if (record == null || (this.existingRecordId != default(int) && record.CreditCardID == this.existingRecordId))
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
    <Hash>c979861d8d6745f1aa4618d54856a4ae</Hash>
</Codenesium>*/