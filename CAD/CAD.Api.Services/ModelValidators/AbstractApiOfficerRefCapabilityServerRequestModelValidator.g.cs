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
	public abstract class AbstractApiOfficerRefCapabilityServerRequestModelValidator : AbstractValidator<ApiOfficerRefCapabilityServerRequestModel>
	{
		private int existingRecordId;

		protected IOfficerRefCapabilityRepository OfficerRefCapabilityRepository { get; private set; }

		public AbstractApiOfficerRefCapabilityServerRequestModelValidator(IOfficerRefCapabilityRepository officerRefCapabilityRepository)
		{
			this.OfficerRefCapabilityRepository = officerRefCapabilityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOfficerRefCapabilityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CapabilityIdRules()
		{
			this.RuleFor(x => x.CapabilityId).MustAsync(this.BeValidOfficerCapabilityByCapabilityId).When(x => !x?.CapabilityId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void OfficerIdRules()
		{
			this.RuleFor(x => x.OfficerId).MustAsync(this.BeValidOfficerByOfficerId).When(x => !x?.OfficerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidOfficerCapabilityByCapabilityId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OfficerRefCapabilityRepository.OfficerCapabilityByCapabilityId(id);

			return record != null;
		}

		protected async Task<bool> BeValidOfficerByOfficerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.OfficerRefCapabilityRepository.OfficerByOfficerId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>5d52b7bd00e847580a484fb6ef417071</Hash>
</Codenesium>*/