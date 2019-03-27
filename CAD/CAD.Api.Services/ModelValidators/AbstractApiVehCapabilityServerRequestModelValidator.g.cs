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
	public abstract class AbstractApiVehCapabilityServerRequestModelValidator : AbstractValidator<ApiVehCapabilityServerRequestModel>
	{
		private int existingRecordId;

		protected IVehCapabilityRepository VehCapabilityRepository { get; private set; }

		public AbstractApiVehCapabilityServerRequestModelValidator(IVehCapabilityRepository vehCapabilityRepository)
		{
			this.VehCapabilityRepository = vehCapabilityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehCapabilityServerRequestModel model, int id)
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
    <Hash>6f655c5c07f69534a8adb0a1c7e88147</Hash>
</Codenesium>*/