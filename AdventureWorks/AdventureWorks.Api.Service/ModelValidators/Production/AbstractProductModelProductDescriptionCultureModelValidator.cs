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

		public bool BeValidProductModel(int id)
		{
			Response response = new Response();

			this.ProductModelRepository.GetById(id,response);
			return response.ProductModels.Count > 0;
		}

		public bool BeValidProductDescription(int id)
		{
			Response response = new Response();

			this.ProductDescriptionRepository.GetById(id,response);
			return response.ProductDescriptions.Count > 0;
		}

		public bool BeValidCulture(string id)
		{
			Response response = new Response();

			this.CultureRepository.GetById(id,response);
			return response.Cultures.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>72ee729273e6df63b09be9b457fb0a08</Hash>
</Codenesium>*/