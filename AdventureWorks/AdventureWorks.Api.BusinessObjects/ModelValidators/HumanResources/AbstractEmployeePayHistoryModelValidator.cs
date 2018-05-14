using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiEmployeePayHistoryModelValidator: AbstractValidator<ApiEmployeePayHistoryModel>
	{
		public new ValidationResult Validate(ApiEmployeePayHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeePayHistoryModel model)
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
    <Hash>f3ac856e87742745884f916e56044e6f</Hash>
</Codenesium>*/