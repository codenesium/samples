using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractOrganizationModelValidator: AbstractValidator<OrganizationModel>
	{
		public new ValidationResult Validate(OrganizationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(OrganizationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>a7d418446a5f1ee6dc5e1bf65ede48c7</Hash>
</Codenesium>*/