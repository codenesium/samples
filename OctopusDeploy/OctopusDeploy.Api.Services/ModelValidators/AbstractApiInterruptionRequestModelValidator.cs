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
	public abstract class AbstractApiInterruptionRequestModelValidator : AbstractValidator<ApiInterruptionRequestModel>
	{
		private string existingRecordId;

		private IInterruptionRepository interruptionRepository;

		public AbstractApiInterruptionRequestModelValidator(IInterruptionRepository interruptionRepository)
		{
			this.interruptionRepository = interruptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiInterruptionRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreatedRules()
		{
		}

		public virtual void EnvironmentIdRules()
		{
			this.RuleFor(x => x.EnvironmentId).Length(0, 50);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void ProjectIdRules()
		{
			this.RuleFor(x => x.ProjectId).Length(0, 50);
		}

		public virtual void RelatedDocumentIdsRules()
		{
		}

		public virtual void ResponsibleTeamIdsRules()
		{
		}

		public virtual void StatusRules()
		{
			this.RuleFor(x => x.Status).Length(0, 50);
		}

		public virtual void TaskIdRules()
		{
			this.RuleFor(x => x.TaskId).Length(0, 50);
		}

		public virtual void TenantIdRules()
		{
			this.RuleFor(x => x.TenantId).Length(0, 50);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).Length(0, 200);
		}
	}
}

/*<Codenesium>
    <Hash>167b98e6bf598a18cd89ea4b5b050639</Hash>
</Codenesium>*/