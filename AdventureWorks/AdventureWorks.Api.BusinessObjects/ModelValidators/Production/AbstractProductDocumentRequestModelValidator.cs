using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductDocumentRequestModelValidator: AbstractValidator<ApiProductDocumentRequestModel>
	{
		public new ValidationResult Validate(ApiProductDocumentRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductDocumentRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DocumentNodeRules()
		{
			this.RuleFor(x => x.DocumentNode).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>8224cf9a8f9cc6e4a4a48726d2d1a1f4</Hash>
</Codenesium>*/