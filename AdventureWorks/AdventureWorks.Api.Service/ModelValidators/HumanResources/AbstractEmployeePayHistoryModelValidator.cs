using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractEmployeePayHistoryModelValidator: AbstractValidator<EmployeePayHistoryModel>
	{
		public new ValidationResult Validate(EmployeePayHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(EmployeePayHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void RateChangeDateRules()
		{
			RuleFor(x => x.RateChangeDate).NotNull();
		}

		public virtual void RateRules()
		{
			RuleFor(x => x.Rate).NotNull();
		}

		public virtual void PayFrequencyRules()
		{
			RuleFor(x => x.PayFrequency).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>519f8fb2fe26d000e3c96311ba150bda</Hash>
</Codenesium>*/