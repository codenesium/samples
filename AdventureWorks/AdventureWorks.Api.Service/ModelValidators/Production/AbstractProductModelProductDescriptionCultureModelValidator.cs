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

		public IProductModelRepository ProductModelRepository {get; set;}
		public IProductDescriptionRepository ProductDescriptionRepository {get; set;}
		public ICultureRepository CultureRepository {get; set;}
		public virtual void ProductDescriptionIDRules()
		{
			RuleFor(x => x.ProductDescriptionID).NotNull();
			RuleFor(x => x.ProductDescriptionID).Must(BeValidProductDescription).When(x => x ?.ProductDescriptionID != null).WithMessage("Invalid reference");
		}

		public virtual void CultureIDRules()
		{
			RuleFor(x => x.CultureID).NotNull();
			RuleFor(x => x.CultureID).Must(BeValidCulture).When(x => x ?.CultureID != null).WithMessage("Invalid reference");
			RuleFor(x => x.CultureID).Length(0,6);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProductModel(int id)
		{
			return this.ProductModelRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProductDescription(int id)
		{
			return this.ProductDescriptionRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidCulture(string id)
		{
			return this.CultureRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>369c988fdad360e95dffbf45095167ca</Hash>
</Codenesium>*/