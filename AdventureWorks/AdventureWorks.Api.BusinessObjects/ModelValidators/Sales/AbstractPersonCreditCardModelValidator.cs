using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiPersonCreditCardModelValidator: AbstractValidator<ApiPersonCreditCardModel>
	{
		public new ValidationResult Validate(ApiPersonCreditCardModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonCreditCardModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICreditCardRepository CreditCardRepository { get; set; }
		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).NotNull();
			this.RuleFor(x => x.CreditCardID).Must(this.BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCreditCard(int id)
		{
			return this.CreditCardRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ed1c52f04e4d012ab87039b51615ae69</Hash>
</Codenesium>*/