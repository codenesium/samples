using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductModelProductDescriptionCultureModelValidator: AbstractValidator<ApiProductModelProductDescriptionCultureModel>
	{
		public new ValidationResult Validate(ApiProductModelProductDescriptionCultureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelProductDescriptionCultureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void CultureIDRules()
		{
			this.RuleFor(x => x.CultureID).NotNull();
			this.RuleFor(x => x.CultureID).Length(0, 6);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductDescriptionIDRules()
		{
			this.RuleFor(x => x.ProductDescriptionID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>820d22d86c1de38d069fa16ee125c6ff</Hash>
</Codenesium>*/