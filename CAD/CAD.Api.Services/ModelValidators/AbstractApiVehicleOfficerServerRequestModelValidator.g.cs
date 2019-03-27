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
	public abstract class AbstractApiVehicleOfficerServerRequestModelValidator : AbstractValidator<ApiVehicleOfficerServerRequestModel>
	{
		private int existingRecordId;

		protected IVehicleOfficerRepository VehicleOfficerRepository { get; private set; }

		public AbstractApiVehicleOfficerServerRequestModelValidator(IVehicleOfficerRepository vehicleOfficerRepository)
		{
			this.VehicleOfficerRepository = vehicleOfficerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleOfficerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void OfficerIdRules()
		{
			this.RuleFor(x => x.OfficerId).MustAsync(this.BeValidOfficerByOfficerId).When(x => !x?.OfficerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void VehicleIdRules()
		{
			this.RuleFor(x => x.VehicleId).MustAsync(this.BeValidVehicleByVehicleId).When(x => !x?.VehicleId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidOfficerByOfficerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleOfficerRepository.OfficerByOfficerId(id);

			return record != null;
		}

		protected async Task<bool> BeValidVehicleByVehicleId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleOfficerRepository.VehicleByVehicleId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8004620990e41d1aee0a68cae0ba752d</Hash>
</Codenesium>*/