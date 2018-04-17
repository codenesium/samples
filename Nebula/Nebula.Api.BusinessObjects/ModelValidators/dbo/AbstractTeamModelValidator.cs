using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

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

		public IOrganizationRepository OrganizationRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrganizationIdRules()
		{
			this.RuleFor(x => x.OrganizationId).NotNull();
			this.RuleFor(x => x.OrganizationId).Must(this.BeValidOrganization).When(x => x ?.OrganizationId != null).WithMessage("Invalid reference");
		}

		private bool BeValidOrganization(int id)
		{
			return this.OrganizationRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>5afc130e1c608dc3503dff76f362256f</Hash>
</Codenesium>*/