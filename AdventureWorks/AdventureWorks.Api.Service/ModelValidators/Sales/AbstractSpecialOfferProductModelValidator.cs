using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSpecialOfferProductModelValidator: AbstractValidator<SpecialOfferProductModel>
	{
		public new ValidationResult Validate(SpecialOfferProductModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SpecialOfferProductModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpecialOfferRepository SpecialOfferRepository {get; set;}
		public IProductRepository ProductRepository {get; set;}
		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
			RuleFor(x => x.ProductID).Must(BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidSpecialOffer(int id)
		{
			return this.SpecialOfferRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>9edf932590100757f1dd08c366899903</Hash>
</Codenesium>*/