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

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>a7fc7ecc828b2805248caff15d92533f</Hash>
</Codenesium>*/