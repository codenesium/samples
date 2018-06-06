using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services

{
	public abstract class AbstractApiTeamRequestModelValidator: AbstractValidator<ApiTeamRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiTeamRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeamRequestModel model, int id)
		{
			this.existingRecordId = id;
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
			this.RuleFor(x => x.OrganizationId).MustAsync(this.BeValidOrganization).When(x => x ?.OrganizationId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidOrganization(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OrganizationRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>67023c950d1fcfbf8835f309f0b8170f</Hash>
</Codenesium>*/