using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ReasonTypeRules()
		{
			this.RuleFor(x => x.ReasonType).NotNull();
			this.RuleFor(x => x.ReasonType).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>ebf05130cf117b94719c30e2b8e3e411</Hash>
</Codenesium>*/