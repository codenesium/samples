using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiPersonCreditCardRequestModelValidator: AbstractValidator<ApiPersonCreditCardRequestModel>
	{
		public new ValidationResult Validate(ApiPersonCreditCardRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonCreditCardRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICreditCardRepository CreditCardRepository { get; set; }
		public virtual void CreditCardIDRules()
		{
			this.RuleFor(x => x.CreditCardID).NotNull();
			this.RuleFor(x => x.CreditCardID).MustAsync(this.BeValidCreditCard).When(x => x ?.CreditCardID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private async Task<bool> BeValidCreditCard(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CreditCardRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6eb98464d480bd0f1f154c5431bbc255</Hash>
</Codenesium>*/