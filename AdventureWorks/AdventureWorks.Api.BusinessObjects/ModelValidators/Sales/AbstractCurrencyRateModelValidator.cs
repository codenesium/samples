using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractCurrencyRateModelValidator: AbstractValidator<CurrencyRateModel>
	{
		public new ValidationResult Validate(CurrencyRateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CurrencyRateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICurrencyRepository CurrencyRepository { get; set; }
		public virtual void CurrencyRateDateRules()
		{
			this.RuleFor(x => x.CurrencyRateDate).NotNull();
		}

		public virtual void FromCurrencyCodeRules()
		{
			this.RuleFor(x => x.FromCurrencyCode).NotNull();
			this.RuleFor(x => x.FromCurrencyCode).Must(this.BeValidCurrency).When(x => x ?.FromCurrencyCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.FromCurrencyCode).Length(0, 3);
		}

		public virtual void ToCurrencyCodeRules()
		{
			this.RuleFor(x => x.ToCurrencyCode).NotNull();
			this.RuleFor(x => x.ToCurrencyCode).Must(this.BeValidCurrency).When(x => x ?.ToCurrencyCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.ToCurrencyCode).Length(0, 3);
		}

		public virtual void AverageRateRules()
		{
			this.RuleFor(x => x.AverageRate).NotNull();
		}

		public virtual void EndOfDayRateRules()
		{
			this.RuleFor(x => x.EndOfDayRate).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCurrency(string id)
		{
			return this.CurrencyRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>721884e093e75a88e49f8d3c4bb98200</Hash>
</Codenesium>*/