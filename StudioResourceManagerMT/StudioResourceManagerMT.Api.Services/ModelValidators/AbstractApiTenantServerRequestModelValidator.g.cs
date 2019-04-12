using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiTenantServerRequestModelValidator : AbstractValidator<ApiTenantServerRequestModel>
	{
		private int existingRecordId;

		protected ITenantRepository TenantRepository { get; private set; }

		public AbstractApiTenantServerRequestModelValidator(ITenantRepository tenantRepository)
		{
			this.TenantRepository = tenantRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTenantServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>284c1a06ac9bcf7880b0b75847e9497b</Hash>
</Codenesium>*/