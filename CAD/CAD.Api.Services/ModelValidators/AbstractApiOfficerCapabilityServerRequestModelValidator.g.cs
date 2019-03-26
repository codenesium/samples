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
	public abstract class AbstractApiOfficerCapabilityServerRequestModelValidator : AbstractValidator<ApiOfficerCapabilityServerRequestModel>
	{
		private int existingRecordId;

		protected IOfficerCapabilityRepository OfficerCapabilityRepository { get; private set; }

		public AbstractApiOfficerCapabilityServerRequestModelValidator(IOfficerCapabilityRepository officerCapabilityRepository)
		{
			this.OfficerCapabilityRepository = officerCapabilityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOfficerCapabilityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void OfficerIdRules()
		{
			this.RuleFor(x => x.OfficerId).MustAsync(this.BeValidOfficerByOfficerId).When(x => !x?.OfficerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidOfficerCapabilityByCapabilityId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OfficerCapabilityRepository.OfficerCapabilityByCapabilityId(id);

			return record != null;
		}

		protected async Task<bool> BeValidOfficerByOfficerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OfficerCapabilityRepository.OfficerByOfficerId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>2a1f6d7755809ca5d87a7d4446c09946</Hash>
</Codenesium>*/