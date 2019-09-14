using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerCapabilitiesServerRequestModelValidator : AbstractValidator<ApiOfficerCapabilitiesServerRequestModel>, IApiOfficerCapabilitiesServerRequestModelValidator
	{
		private int existingRecordId;

		protected IOfficerCapabilitiesRepository OfficerCapabilitiesRepository { get; private set; }

		public ApiOfficerCapabilitiesServerRequestModelValidator(IOfficerCapabilitiesRepository officerCapabilitiesRepository)
		{
			this.OfficerCapabilitiesRepository = officerCapabilitiesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOfficerCapabilitiesServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOfficerCapabilitiesServerRequestModel model)
		{
			this.CapabilityIdRules();
			this.OfficerIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerCapabilitiesServerRequestModel model)
		{
			this.CapabilityIdRules();
			this.OfficerIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void CapabilityIdRules()
		{
			this.RuleFor(x => x.CapabilityId).MustAsync(this.BeValidOffCapabilityByCapabilityId).When(x => !x?.CapabilityId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void OfficerIdRules()
		{
			this.RuleFor(x => x.OfficerId).MustAsync(this.BeValidOfficerByOfficerId).When(x => !x?.OfficerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidOffCapabilityByCapabilityId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OfficerCapabilitiesRepository.OffCapabilityByCapabilityId(id);

			return record != null;
		}

		protected async Task<bool> BeValidOfficerByOfficerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OfficerCapabilitiesRepository.OfficerByOfficerId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>06100b5b74eed2dd6f40085e9652a200</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/