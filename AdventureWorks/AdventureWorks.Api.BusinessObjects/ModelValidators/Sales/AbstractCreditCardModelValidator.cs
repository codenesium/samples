using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiCreditCardModelValidator: AbstractValidator<ApiCreditCardModel>
	{
		public new ValidationResult Validate(ApiCreditCardModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCreditCardModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICreditCardRepository CreditCardRepository { get; set; }
		public virtual void CardNumberRules()
		{
			this.RuleFor(x => x.CardNumber).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetCardNumber).When(x => x ?.CardNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCreditCardModel.CardNumber));
			this.RuleFor(x => x.CardNumber).Length(0, 25);
		}

		public virtual void CardTypeRules()
		{
			this.RuleFor(x => x.CardType).NotNull();
			this.RuleFor(x => x.CardType).Length(0, 50);
		}

		public virtual void ExpMonthRules()
		{
			this.RuleFor(x => x.ExpMonth).NotNull();
		}

		public virtual void ExpYearRules()
		{
			this.RuleFor(x => x.ExpYear).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeUniqueGetCardNumber(ApiCreditCardModel model)
		{
			return this.CreditCardRepository.GetCardNumber(model.CardNumber) == null;
		}
	}
}

/*<Codenesium>
    <Hash>1fd82c7ecdfe5a099f918f61b7f078cf</Hash>
</Codenesium>*/