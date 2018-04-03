using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductModelProductDescriptionCultureModelValidator: AbstractValidator<ProductModelProductDescriptionCultureModel>
	{
		public new ValidationResult Validate(ProductModelProductDescriptionCultureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductModelProductDescriptionCultureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductDescriptionIDRules()
		{
			RuleFor(x => x.ProductDescriptionID).NotNull();
		}

		public virtual void CultureIDRules()
		{
			RuleFor(x => x.CultureID).NotNull();
			RuleFor(x => x.CultureID).Length(0,6);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>2e07aa77a7bd82c4660955e02026e5e5</Hash>
</Codenesium>*/