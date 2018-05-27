using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiTeamRequestModelValidator: AbstractValidator<ApiTeamRequestModel>
	{
		public new ValidationResult Validate(ApiTeamRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeamRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IOrganizationRepository OrganizationRepository { get; set; }
		public ITeamRepository TeamRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTeamRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrganizationIdRules()
		{
			this.RuleFor(x => x.OrganizationId).NotNull();
			this.RuleFor(x => x.OrganizationId).MustAsync(this.BeValidOrganization).When(x => x ?.OrganizationId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidOrganization(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OrganizationRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeUniqueGetName(ApiTeamRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.TeamRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>67a847454193eed3cfbfc3968dc06240</Hash>
</Codenesium>*/