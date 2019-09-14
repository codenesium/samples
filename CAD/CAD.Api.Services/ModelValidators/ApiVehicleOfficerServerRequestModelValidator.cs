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
	public class ApiVehicleOfficerServerRequestModelValidator : AbstractValidator<ApiVehicleOfficerServerRequestModel>, IApiVehicleOfficerServerRequestModelValidator
	{
		private int existingRecordId;

		protected IVehicleOfficerRepository VehicleOfficerRepository { get; private set; }

		public ApiVehicleOfficerServerRequestModelValidator(IVehicleOfficerRepository vehicleOfficerRepository)
		{
			this.VehicleOfficerRepository = vehicleOfficerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleOfficerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVehicleOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.VehicleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVehicleOfficerServerRequestModel model)
		{
			this.OfficerIdRules();
			this.VehicleIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>2e6329a61c19716a01b780fce6790f34</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/