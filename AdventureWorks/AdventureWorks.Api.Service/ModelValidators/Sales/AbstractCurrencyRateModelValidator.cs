using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public ICurrencyRepository CurrencyRepository {get; set;}
		public virtual void CurrencyRateDateRules()
		{
			RuleFor(x => x.CurrencyRateDate).NotNull();
		}

		public virtual void FromCurrencyCodeRules()
		{
			RuleFor(x => x.FromCurrencyCode).NotNull();
			RuleFor(x => x.FromCurrencyCode).Must(BeValidCurrency).When(x => x ?.FromCurrencyCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.FromCurrencyCode).Length(0,3);
		}

		public virtual void ToCurrencyCodeRules()
		{
			RuleFor(x => x.ToCurrencyCode).NotNull();
			RuleFor(x => x.ToCurrencyCode).Must(BeValidCurrency).When(x => x ?.ToCurrencyCode != null).WithMessage("Invalid reference");
			RuleFor(x => x.ToCurrencyCode).Length(0,3);
		}

		public virtual void AverageRateRules()
		{
			RuleFor(x => x.AverageRate).NotNull();
		}

		public virtual void EndOfDayRateRules()
		{
			RuleFor(x => x.EndOfDayRate).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidCurrency(string id)
		{
			return this.CurrencyRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>9d84ecc92c39f567f4d3bdbd9bdbe480</Hash>
</Codenesium>*/