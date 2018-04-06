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

		public bool BeValidProductModel(int id)
		{
			Response response = new Response();

			this.ProductModelRepository.GetById(id,response);
			return response.ProductModels.Count > 0;
		}

		public bool BeValidIllustration(int id)
		{
			Response response = new Response();

			this.IllustrationRepository.GetById(id,response);
			return response.Illustrations.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>baf6e0096855f28aa7ff8bd51bbaf924</Hash>
</Codenesium>*/