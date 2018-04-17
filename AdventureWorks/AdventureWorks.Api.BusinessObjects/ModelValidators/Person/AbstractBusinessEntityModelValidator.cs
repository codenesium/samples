using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractBusinessEntityModelValidator: AbstractValidator<BusinessEntityModel>
	{
		public new ValidationResult Validate(BusinessEntityModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BusinessEntityModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>81dd82838a7ed4418b9ce993d16118aa</Hash>
</Codenesium>*/