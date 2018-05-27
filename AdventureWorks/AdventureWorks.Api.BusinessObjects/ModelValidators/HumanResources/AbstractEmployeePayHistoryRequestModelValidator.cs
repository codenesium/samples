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
	public abstract class AbstractApiEmployeePayHistoryRequestModelValidator: AbstractValidator<ApiEmployeePayHistoryRequestModel>
	{
		public new ValidationResult Validate(ApiEmployeePayHistoryRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeePayHistoryRequestModel model)
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
    <Hash>f65f997d080432de00813d26edccd03d</Hash>
</Codenesium>*/