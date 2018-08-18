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
	public abstract class AbstractApiDeploymentHistoryRequestModelValidator : AbstractValidator<ApiDeploymentHistoryRequestModel>
	{
		private string existingRecordId;

		private IDeploymentHistoryRepository deploymentHistoryRepository;

		public AbstractApiDeploymentHistoryRequestModelValidator(IDeploymentHistoryRepository deploymentHistoryRepository)
		{
			this.deploymentHistoryRepository = deploymentHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeploymentHistoryRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ChannelIdRules()
		{
			this.RuleFor(x => x.ChannelId).Length(0, 50);
		}

		public virtual void ChannelNameRules()
		{
			this.RuleFor(x => x.ChannelName).Length(0, 200);
		}

		public virtual void CompletedTimeRules()
		{
		}

		public virtual void CreatedRules()
		{
		}

		public virtual void DeployedByRules()
		{
			this.RuleFor(x => x.DeployedBy).Length(0, 200);
		}

		public virtual void DeploymentNameRules()
		{
			this.RuleFor(x => x.DeploymentName).Length(0, 200);
		}

		public virtual void DurationSecondsRules()
		{
		}

		public virtual void EnvironmentIdRules()
		{
			this.RuleFor(x => x.EnvironmentId).Length(0, 50);
		}

		public virtual void EnvironmentNameRules()
		{
			this.RuleFor(x => x.EnvironmentName).Length(0, 200);
		}

		public virtual void ProjectIdRules()
		{
			this.RuleFor(x => x.ProjectId).Length(0, 50);
		}

		public virtual void ProjectNameRules()
		{
			this.RuleFor(x => x.ProjectName).Length(0, 200);
		}

		public virtual void ProjectSlugRules()
		{
			this.RuleFor(x => x.ProjectSlug).Length(0, 210);
		}

		public virtual void QueueTimeRules()
		{
		}

		public virtual void ReleaseIdRules()
		{
			this.RuleFor(x => x.ReleaseId).Length(0, 150);
		}

		public virtual void ReleaseVersionRules()
		{
			this.RuleFor(x => x.ReleaseVersion).Length(0, 100);
		}

		public virtual void StartTimeRules()
		{
		}

		public virtual void TaskIdRules()
		{
			this.RuleFor(x => x.TaskId).Length(0, 50);
		}

		public virtual void TaskStateRules()
		{
			this.RuleFor(x => x.TaskState).Length(0, 50);
		}

		public virtual void TenantIdRules()
		{
			this.RuleFor(x => x.TenantId).Length(0, 50);
		}

		public virtual void TenantNameRules()
		{
			this.RuleFor(x => x.TenantName).Length(0, 200);
		}
	}
}

/*<Codenesium>
    <Hash>ea21bf41c0970c971f6b94bd01bc2fb8</Hash>
</Codenesium>*/