using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShiftModelValidator: AbstractValidator<ApiShiftModel>
	{
		public new ValidationResult Validate(ApiShiftModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShiftModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x.EndTime).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x.StartTime).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>fbb622ed1c6f2bc54d3ba1bde3aea1ea</Hash>
</Codenesium>*/