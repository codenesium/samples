using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductDescriptionModelValidator: AbstractValidator<ProductDescriptionModel>
	{
		public new ValidationResult Validate(ProductDescriptionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductDescriptionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			RuleFor(x => x.Description).NotNull();
			RuleFor(x => x.Description).Length(0,400);
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
    <Hash>1c24a9a6fd26e45307acafcaaf31eaa9</Hash>
</Codenesium>*/