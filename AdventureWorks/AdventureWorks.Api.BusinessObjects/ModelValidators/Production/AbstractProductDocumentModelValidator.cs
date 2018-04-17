using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IProductRepository ProductRepository { get; set; }
		public IDocumentRepository DocumentRepository { get; set; }
		public virtual void DocumentNodeRules()
		{
			this.RuleFor(x => x.DocumentNode).NotNull();
			this.RuleFor(x => x.DocumentNode).Must(this.BeValidDocument).When(x => x ?.DocumentNode != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
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
    <Hash>fcfec21e7a580a6676fa3a518d01c781</Hash>
</Codenesium>*/