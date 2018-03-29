using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductInventoryModelValidator: AbstractValidator<ProductInventoryModel>
	{
		public new ValidationResult Validate(ProductInventoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductInventoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository {get; set;}
		public ILocationRepository LocationRepository {get; set;}
		public virtual void LocationIDRules()
		{
			RuleFor(x => x.LocationID).NotNull();
			RuleFor(x => x.LocationID).Must(BeValidLocation).When(x => x ?.LocationID != null).WithMessage("Invalid reference");
		}

		public virtual void ShelfRules()
		{
			RuleFor(x => x.Shelf).NotNull();
			RuleFor(x => x.Shelf).Length(0,10);
		}

		public virtual void BinRules()
		{
			RuleFor(x => x.Bin).NotNull();
		}

		public virtual void QuantityRules()
		{
			RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
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

		public bool BeValidLocation(short id)
		{
			Response response = new Response();

			this.LocationRepository.GetById(id,response);
			return response.Locations.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>61f6bcc0121514af52cf491eb7979788</Hash>
</Codenesium>*/