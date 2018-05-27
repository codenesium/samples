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
	public abstract class AbstractApiCreditCardRequestModelValidator: AbstractValidator<ApiCreditCardRequestModel>
	{
		public new ValidationResult Validate(ApiCreditCardRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCreditCardRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICreditCardRepository CreditCardRepository { get; set; }
		public virtual void CardNumberRules()
		{
			this.RuleFor(x => x.CardNumber).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetCardNumber).When(x => x ?.CardNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCreditCardRequestModel.CardNumber));
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

		private async Task<bool> BeUniqueGetCardNumber(ApiCreditCardRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.CreditCardRepository.GetCardNumber(model.CardNumber);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>b06c48d7842e42024aa1fcc6298878c4</Hash>
</Codenesium>*/