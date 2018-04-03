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

		public virtual void DocumentNodeRules()
		{
			RuleFor(x => x.DocumentNode).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>71a8d2d03d878e7d4e80bc771f7c1978</Hash>
</Codenesium>*/