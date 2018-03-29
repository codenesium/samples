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

		public bool BeValidProduct(int id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id,response);
			return response.Products.Count > 0;
		}

		public bool BeValidProductPhoto(int id)
		{
			Response response = new Response();

			this.ProductPhotoRepository.GetById(id,response);
			return response.ProductPhotoes.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>dbe1fb22fe2d16906926132f5c808dbf</Hash>
</Codenesium>*/