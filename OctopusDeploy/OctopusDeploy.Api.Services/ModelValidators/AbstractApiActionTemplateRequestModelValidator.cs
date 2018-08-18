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
	public abstract class AbstractApiActionTemplateRequestModelValidator : AbstractValidator<ApiActionTemplateRequestModel>
	{
		private string existingRecordId;

		private IActionTemplateRepository actionTemplateRepository;

		public AbstractApiActionTemplateRequestModelValidator(IActionTemplateRepository actionTemplateRepository)
		{
			this.actionTemplateRepository = actionTemplateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiActionTemplateRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ActionTypeRules()
		{
			this.RuleFor(x => x.ActionType).Length(0, 50);
		}

		public virtual void CommunityActionTemplateIdRules()
		{
			this.RuleFor(x => x.CommunityActionTemplateId).Length(0, 50);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiActionTemplateRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void VersionRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiActionTemplateRequestModel model,  CancellationToken cancellationToken)
		{
			ActionTemplate record = await this.actionTemplateRepository.ByName(model.Name);

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
    <Hash>4becbdde226bc7b8870e818b784ae186</Hash>
</Codenesium>*/