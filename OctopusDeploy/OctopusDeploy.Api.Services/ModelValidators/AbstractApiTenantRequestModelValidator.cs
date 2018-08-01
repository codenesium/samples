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
	public abstract class AbstractApiTenantRequestModelValidator : AbstractValidator<ApiTenantRequestModel>
	{
		private string existingRecordId;

		private ITenantRepository tenantRepository;

		public AbstractApiTenantRequestModelValidator(ITenantRepository tenantRepository)
		{
			this.tenantRepository = tenantRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTenantRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DataVersionRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTenantRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void ProjectIdsRules()
		{
		}

		public virtual void TenantTagsRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiTenantRequestModel model,  CancellationToken cancellationToken)
		{
			Tenant record = await this.tenantRepository.ByName(model.Name);

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
    <Hash>cf9de4d241203c97502912030e1453fa</Hash>
</Codenesium>*/