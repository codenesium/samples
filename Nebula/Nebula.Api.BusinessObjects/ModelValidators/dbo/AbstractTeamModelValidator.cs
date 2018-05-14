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
			return this.OrganizationRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>95eeff3d7b65ff8c66272825b29828c1</Hash>
</Codenesium>*/