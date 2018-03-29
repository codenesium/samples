using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>6131c172910e9d70956e0090167f2f85</Hash>
</Codenesium>*/