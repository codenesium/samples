using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiTenantRequestModelValidator : AbstractValidator<ApiTenantRequestModel>
	{
		private int existingRecordId;

		private ITenantRepository tenantRepository;

		public AbstractApiTenantRequestModelValidator(ITenantRepository tenantRepository)
		{
			this.tenantRepository = tenantRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTenantRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>0c5ae706ca24602fcf30df168081c358</Hash>
</Codenesium>*/