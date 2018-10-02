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
	public abstract class AbstractApiMachineRequestModelValidator : AbstractValidator<ApiMachineRequestModel>
	{
		private int existingRecordId;

		private IMachineRepository machineRepository;

		public AbstractApiMachineRequestModelValidator(IMachineRepository machineRepository)
		{
			this.machineRepository = machineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByMachineGuid).When(x => x?.MachineGuid != null).WithMessage("Violates unique constraint").WithName(nameof(ApiMachineRequestModel.MachineGuid));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByMachineGuid(ApiMachineRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>cdeda3ec2a67a2c42912ae59fdd76a72</Hash>
</Codenesium>*/