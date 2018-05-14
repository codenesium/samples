using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductDocumentModelValidator: AbstractValidator<ApiProductDocumentModel>
	{
		public new ValidationResult Validate(ApiProductDocumentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductDocumentModel model)
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
    <Hash>efeeec0ea79503de1aeb73246334803c</Hash>
</Codenesium>*/