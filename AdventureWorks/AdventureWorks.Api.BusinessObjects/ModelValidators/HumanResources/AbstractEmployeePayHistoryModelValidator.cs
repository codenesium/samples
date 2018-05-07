using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PayFrequencyRules()
		{
			this.RuleFor(x => x.PayFrequency).NotNull();
		}

		public virtual void RateRules()
		{
			this.RuleFor(x => x.Rate).NotNull();
		}

		public virtual void RateChangeDateRules()
		{
			this.RuleFor(x => x.RateChangeDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>99f5872ca6f664e0f67e4a2bb14734be</Hash>
</Codenesium>*/