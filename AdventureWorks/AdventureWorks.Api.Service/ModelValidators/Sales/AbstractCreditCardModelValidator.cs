using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractCreditCardModelValidator: AbstractValidator<CreditCardModel>
	{
		public new ValidationResult Validate(CreditCardModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CreditCardModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void CardTypeRules()
		{
			RuleFor(x => x.CardType).NotNull();
			RuleFor(x => x.CardType).Length(0,50);
		}

		public virtual void CardNumberRules()
		{
			RuleFor(x => x.CardNumber).NotNull();
			RuleFor(x => x.CardNumber).Length(0,25);
		}

		public virtual void ExpMonthRules()
		{
			RuleFor(x => x.ExpMonth).NotNull();
		}

		public virtual void ExpYearRules()
		{
			RuleFor(x => x.ExpYear).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>3d4e1b6efe058fbae1db83b79529bc10</Hash>
</Codenesium>*/