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

		public virtual void CardNumberRules()
		{
			this.RuleFor(x => x.CardNumber).NotNull();
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
	}
}

/*<Codenesium>
    <Hash>255beeeb1e04a8519a25e95d3eec6005</Hash>
</Codenesium>*/