using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public IProductRepository ProductRepository {get; set;}
		public IProductPhotoRepository ProductPhotoRepository {get; set;}
		public virtual void ProductPhotoIDRules()
		{
			RuleFor(x => x.ProductPhotoID).NotNull();
			RuleFor(x => x.ProductPhotoID).Must(BeValidProductPhoto).When(x => x ?.ProductPhotoID != null).WithMessage("Invalid reference");
		}

		public virtual void PrimaryRules()
		{
			RuleFor(x => x.Primary).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
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
    <Hash>d6acca6d04c4306816e235942416bb3f</Hash>
</Codenesium>*/