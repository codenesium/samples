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
	public abstract class AbstractApiProductModelProductDescriptionCultureRequestModelValidator: AbstractValidator<ApiProductModelProductDescriptionCultureRequestModel>
	{
		public new ValidationResult Validate(ApiProductModelProductDescriptionCultureRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelProductDescriptionCultureRequestModel model)
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
    <Hash>64f157a49f234cfa0ecc058a88b59dd1</Hash>
</Codenesium>*/