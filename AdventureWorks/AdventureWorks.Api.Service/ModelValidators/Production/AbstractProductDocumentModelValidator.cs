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

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidDocument(Guid id)
		{
			return this.DocumentRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>6ac16d32220b542e8b7feb45541565eb</Hash>
</Codenesium>*/