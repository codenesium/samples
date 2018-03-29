using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

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
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>3d733b9fd6b93e4a5cf3efd5394d2d23</Hash>
</Codenesium>*/