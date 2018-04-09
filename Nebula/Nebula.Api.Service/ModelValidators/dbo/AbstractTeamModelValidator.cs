using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractTeamModelValidator: AbstractValidator<TeamModel>
	{
		public new ValidationResult Validate(TeamModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(TeamModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IOrganizationRepository OrganizationRepository {get; set;}
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void OrganizationIdRules()
		{
			RuleFor(x => x.OrganizationId).NotNull();
			RuleFor(x => x.OrganizationId).Must(BeValidOrganization).When(x => x ?.OrganizationId != null).WithMessage("Invalid reference");
		}

		private bool BeValidOrganization(int id)
		{
			return this.OrganizationRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>b567b9ae62973d858e0e5bea6fb0c434</Hash>
</Codenesium>*/