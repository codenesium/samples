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
	public abstract class AbstractApiVehicleServerRequestModelValidator : AbstractValidator<ApiVehicleServerRequestModel>
	{
		private int existingRecordId;

		protected IVehicleRepository VehicleRepository { get; private set; }

		public AbstractApiVehicleServerRequestModelValidator(IVehicleRepository vehicleRepository)
		{
			this.VehicleRepository = vehicleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleServerRequestModel model, int id)
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
    <Hash>97b11c54ea925590ccad8e55b1d39e4f</Hash>
</Codenesium>*/