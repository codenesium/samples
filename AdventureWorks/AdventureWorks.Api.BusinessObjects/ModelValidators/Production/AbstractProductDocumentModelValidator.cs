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

		public IDocumentRepository DocumentRepository { get; set; }
		public IProductRepository ProductRepository { get; set; }
		public virtual void DocumentNodeRules()
		{
			this.RuleFor(x => x.DocumentNode).NotNull();
			this.RuleFor(x => x.DocumentNode).Must(this.BeValidDocument).When(x => x ?.DocumentNode != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidDocument(Guid id)
		{
			return this.DocumentRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>da086f53f45e3d4915bd5209bab66b3a</Hash>
</Codenesium>*/