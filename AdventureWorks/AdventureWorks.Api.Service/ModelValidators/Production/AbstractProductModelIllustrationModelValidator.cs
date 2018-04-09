using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductModelIllustrationModelValidator: AbstractValidator<ProductModelIllustrationModel>
	{
		public new ValidationResult Validate(ProductModelIllustrationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductModelIllustrationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductModelRepository ProductModelRepository {get; set;}
		public IIllustrationRepository IllustrationRepository {get; set;}
		public virtual void IllustrationIDRules()
		{
			RuleFor(x => x.IllustrationID).NotNull();
			RuleFor(x => x.IllustrationID).Must(BeValidIllustration).When(x => x ?.IllustrationID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProductModel(int id)
		{
			return this.ProductModelRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidIllustration(int id)
		{
			return this.IllustrationRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>4debc8de1bc57a9b3c9fd919704ae654</Hash>
</Codenesium>*/