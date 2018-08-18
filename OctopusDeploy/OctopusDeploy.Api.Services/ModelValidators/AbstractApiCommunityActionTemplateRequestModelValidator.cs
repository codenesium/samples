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
	public abstract class AbstractApiCommunityActionTemplateRequestModelValidator : AbstractValidator<ApiCommunityActionTemplateRequestModel>
	{
		private string existingRecordId;

		private ICommunityActionTemplateRepository communityActionTemplateRepository;

		public AbstractApiCommunityActionTemplateRequestModelValidator(ICommunityActionTemplateRepository communityActionTemplateRepository)
		{
			this.communityActionTemplateRepository = communityActionTemplateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCommunityActionTemplateRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => x?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCommunityActionTemplateRequestModel.ExternalId));
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCommunityActionTemplateRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		private async Task<bool> BeUniqueByExternalId(ApiCommunityActionTemplateRequestModel model,  CancellationToken cancellationToken)
		{
			CommunityActionTemplate record = await this.communityActionTemplateRepository.ByExternalId(model.ExternalId);

			if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByName(ApiCommunityActionTemplateRequestModel model,  CancellationToken cancellationToken)
		{
			CommunityActionTemplate record = await this.communityActionTemplateRepository.ByName(model.Name);

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
    <Hash>6d027f82214967fa8602c86a0f552489</Hash>
</Codenesium>*/