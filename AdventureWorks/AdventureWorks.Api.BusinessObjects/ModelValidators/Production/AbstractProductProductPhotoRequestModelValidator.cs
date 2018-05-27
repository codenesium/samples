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
	public abstract class AbstractApiProductProductPhotoRequestModelValidator: AbstractValidator<ApiProductProductPhotoRequestModel>
	{
		public new ValidationResult Validate(ApiProductProductPhotoRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductProductPhotoRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PrimaryRules()
		{
			this.RuleFor(x => x.Primary).NotNull();
		}

		public virtual void ProductPhotoIDRules()
		{
			this.RuleFor(x => x.ProductPhotoID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>840fab371e322c8cf20be0020f35470f</Hash>
</Codenesium>*/