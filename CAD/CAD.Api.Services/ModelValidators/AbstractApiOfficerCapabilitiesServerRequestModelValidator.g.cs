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
	public abstract class AbstractApiOfficerCapabilitiesServerRequestModelValidator : AbstractValidator<ApiOfficerCapabilitiesServerRequestModel>
	{
		private int existingRecordId;

		protected IOfficerCapabilitiesRepository OfficerCapabilitiesRepository { get; private set; }

		public AbstractApiOfficerCapabilitiesServerRequestModelValidator(IOfficerCapabilitiesRepository officerCapabilitiesRepository)
		{
			this.OfficerCapabilitiesRepository = officerCapabilitiesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOfficerCapabilitiesServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>4cefe55e93357b451feee68466468380</Hash>
</Codenesium>*/