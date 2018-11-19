using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiTeamServerRequestModelValidator : AbstractValidator<ApiTeamServerRequestModel>
	{
		private int existingRecordId;

		private ITeamRepository teamRepository;

		public AbstractApiTeamServerRequestModelValidator(ITeamRepository teamRepository)
		{
			this.teamRepository = teamRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeamServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiTeamServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void OrganizationIdRules()
		{
			this.RuleFor(x => x.OrganizationId).MustAsync(this.BeValidOrganizationByOrganizationId).When(x => !x?.OrganizationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		private async Task<bool> BeValidOrganizationByOrganizationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teamRepository.OrganizationByOrganizationId(id);

			return record != null;
		}

		private async Task<bool> BeUniqueByName(ApiTeamServerRequestModel model,  CancellationToken cancellationToken)
		{
			Team record = await this.teamRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>710171c3d07a690682ef68c9af708a66</Hash>
</Codenesium>*/