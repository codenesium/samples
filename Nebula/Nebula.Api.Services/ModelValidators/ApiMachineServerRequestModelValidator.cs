using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiMachineServerRequestModelValidator : AbstractValidator<ApiMachineServerRequestModel>, IApiMachineServerRequestModelValidator
	{
		private int existingRecordId;

		protected IMachineRepository MachineRepository { get; private set; }

		public ApiMachineServerRequestModelValidator(IMachineRepository machineRepository)
		{
			this.MachineRepository = machineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineServerRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineServerRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void JwtKeyRules()
		{
			this.RuleFor(x => x.JwtKey).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.JwtKey).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastIpAddressRules()
		{
			this.RuleFor(x => x.LastIpAddress).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastIpAddress).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void MachineGuidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByMachineGuid).When(x => (!x?.MachineGuid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiMachineServerRequestModel.MachineGuid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByMachineGuid(ApiMachineServerRequestModel model,  CancellationToken cancellationToken)
		{
			Machine record = await this.MachineRepository.ByMachineGuid(model.MachineGuid);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>968f7456f0e9e9d8384ca415c6be29d8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/