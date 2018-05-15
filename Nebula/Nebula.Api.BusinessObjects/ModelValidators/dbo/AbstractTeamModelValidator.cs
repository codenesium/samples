using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiTeamModelValidator: AbstractValidator<ApiTeamModel>
	{
		public new ValidationResult Validate(ApiTeamModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeamModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IOrganizationRepository OrganizationRepository { get; set; }
		public ITeamRepository TeamRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrganizationIdRules()
		{
			this.RuleFor(x => x.OrganizationId).NotNull();
			this.RuleFor(x => x.OrganizationId).Must(this.BeValidOrganization).When(x => x ?.OrganizationId != null).WithMessage("Invalid reference");
		}

		private bool BeValidOrganization(int id)
		{
			return this.OrganizationRepository.Get(id) != null;
		}

		private bool BeUniqueName(ApiTeamModel model)
		{
			return this.TeamRepository.Name(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>70715176c24287e48884640afacdbad6</Hash>
</Codenesium>*/