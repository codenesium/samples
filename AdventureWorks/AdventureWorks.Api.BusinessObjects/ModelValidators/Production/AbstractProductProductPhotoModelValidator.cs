using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductProductPhotoModelValidator: AbstractValidator<ProductProductPhotoModel>
	{
		public new ValidationResult Validate(ProductProductPhotoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductProductPhotoModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository { get; set; }
		public IProductPhotoRepository ProductPhotoRepository { get; set; }
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
			this.RuleFor(x => x.ProductPhotoID).Must(this.BeValidProductPhoto).When(x => x ?.ProductPhotoID != null).WithMessage("Invalid reference");
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProductPhoto(int id)
		{
			return this.ProductPhotoRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>4b64280e8f4712a940d62731544b98f6</Hash>
</Codenesium>*/