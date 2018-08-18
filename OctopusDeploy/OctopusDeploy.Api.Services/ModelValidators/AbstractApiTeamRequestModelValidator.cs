using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiTeamRequestModelValidator : AbstractValidator<ApiTeamRequestModel>
	{
		private string existingRecordId;

		private ITeamRepository teamRepository;

		public AbstractApiTeamRequestModelValidator(ITeamRepository teamRepository)
		{
			this.teamRepository = teamRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeamRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EnvironmentIdsRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void MemberUserIdsRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTeamRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void ProjectGroupIdsRules()
		{
		}

		public virtual void ProjectIdsRules()
		{
		}

		public virtual void TenantIdsRules()
		{
		}

		public virtual void TenantTagsRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiTeamRequestModel model,  CancellationToken cancellationToken)
		{
			Team record = await this.teamRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>08d443b9a47cf8449d9b3f412f941277</Hash>
</Codenesium>*/