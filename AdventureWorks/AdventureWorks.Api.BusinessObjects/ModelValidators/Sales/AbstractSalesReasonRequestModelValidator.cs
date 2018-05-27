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
	public abstract class AbstractApiSalesReasonRequestModelValidator: AbstractValidator<ApiSalesReasonRequestModel>
	{
		public new ValidationResult Validate(ApiSalesReasonRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesReasonRequestModel model)
		{
			return await base.ValidateAsync(model);
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

		public virtual void ReasonTypeRules()
		{
			this.RuleFor(x => x.ReasonType).NotNull();
			this.RuleFor(x => x.ReasonType).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>312cdef23c9cb58db1ddba1a993d5943</Hash>
</Codenesium>*/