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

		public virtual void CurrencyRateDateRules()
		{
			RuleFor(x => x.CurrencyRateDate).NotNull();
		}

		public virtual void FromCurrencyCodeRules()
		{
			RuleFor(x => x.FromCurrencyCode).NotNull();
			RuleFor(x => x.FromCurrencyCode).Length(0,3);
		}

		public virtual void ToCurrencyCodeRules()
		{
			RuleFor(x => x.ToCurrencyCode).NotNull();
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
	}
}

/*<Codenesium>
    <Hash>78044d67dff73c42ff4bd74c2ab9845f</Hash>
</Codenesium>*/