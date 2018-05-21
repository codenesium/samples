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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTeamModel.Name));
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

		private bool BeUniqueGetName(ApiTeamModel model)
		{
			return this.TeamRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>1526a081e292efcda3bb88f4153172f1</Hash>
</Codenesium>*/