using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductDocumentModelValidator: AbstractValidator<ProductDocumentModel>
	{
		public new ValidationResult Validate(ProductDocumentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductDocumentModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository {get; set;}
		public IDocumentRepository DocumentRepository {get; set;}
		public virtual void DocumentNodeRules()
		{
			RuleFor(x => x.DocumentNode).NotNull();
			RuleFor(x => x.DocumentNode).Must(BeValidDocument).When(x => x ?.DocumentNode != null).WithMessage("Invalid reference");
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

		public bool BeValidDocument(Guid id)
		{
			Response response = new Response();

			this.DocumentRepository.GetById(id,response);
			return response.Documents.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>f9dcee080223fdcb9aed6c614bfc628f</Hash>
</Codenesium>*/