using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesReasonModelValidator: AbstractValidator<SalesReasonModel>
	{
		public new ValidationResult Validate(SalesReasonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesReasonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void ReasonTypeRules()
		{
			RuleFor(x => x.ReasonType).NotNull();
			RuleFor(x => x.ReasonType).Length(0,50);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>79f48d5b1c534b7e01f1795d0da0f266</Hash>
</Codenesium>*/