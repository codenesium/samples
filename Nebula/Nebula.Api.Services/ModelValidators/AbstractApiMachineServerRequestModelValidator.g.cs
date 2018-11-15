using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiMachineServerRequestModelValidator : AbstractValidator<ApiMachineServerRequestModel>
	{
		private int existingRecordId;

		private IMachineRepository machineRepository;

		public AbstractApiMachineServerRequestModelValidator(IMachineRepository machineRepository)
		{
			this.machineRepository = machineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 2147483647);
		}

		public virtual void JwtKeyRules()
		{
			this.RuleFor(x => x.JwtKey).NotNull();
			this.RuleFor(x => x.JwtKey).Length(0, 128);
		}

		public virtual void LastIpAddressRules()
		{
			this.RuleFor(x => x.LastIpAddress).NotNull();
			this.RuleFor(x => x.LastIpAddress).Length(0, 128);
		}

		public virtual void MachineGuidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByMachineGuid).When(x => !x?.MachineGuid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiMachineServerRequestModel.MachineGuid));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByMachineGuid(ApiMachineServerRequestModel model,  CancellationToken cancellationToken)
		{
			Machine record = await this.machineRepository.ByMachineGuid(model.MachineGuid);

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
    <Hash>008e825c3fddb88c7891e71d4d542311</Hash>
</Codenesium>*/