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
	public abstract class AbstractApiProjectTriggerRequestModelValidator : AbstractValidator<ApiProjectTriggerRequestModel>
	{
		private string existingRecordId;

		private IProjectTriggerRepository projectTriggerRepository;

		public AbstractApiProjectTriggerRequestModelValidator(IProjectTriggerRepository projectTriggerRepository)
		{
			this.projectTriggerRepository = projectTriggerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProjectTriggerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void IsDisabledRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByProjectIdName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectTriggerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void ProjectIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByProjectIdName).When(x => x?.ProjectId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProjectTriggerRequestModel.ProjectId));
			this.RuleFor(x => x.ProjectId).Length(0, 50);
		}

		public virtual void TriggerTypeRules()
		{
			this.RuleFor(x => x.TriggerType).Length(0, 50);
		}

		private async Task<bool> BeUniqueByProjectIdName(ApiProjectTriggerRequestModel model,  CancellationToken cancellationToken)
		{
			ProjectTrigger record = await this.projectTriggerRepository.ByProjectIdName(model.ProjectId, model.Name);

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
    <Hash>1453271163b5f6b4c95539463f6f6cf1</Hash>
</Codenesium>*/