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
	public abstract class AbstractApiMachineRefTeamRequestModelValidator : AbstractValidator<ApiMachineRefTeamRequestModel>
	{
		private int existingRecordId;

		private IMachineRefTeamRepository machineRefTeamRepository;

		public AbstractApiMachineRefTeamRequestModelValidator(IMachineRefTeamRepository machineRefTeamRepository)
		{
			this.machineRefTeamRepository = machineRefTeamRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineRefTeamRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void MachineIdRules()
		{
			this.RuleFor(x => x.MachineId).MustAsync(this.BeValidMachine).When(x => x?.MachineId != null).WithMessage("Invalid reference");
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeam).When(x => x?.TeamId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidMachine(int id,  CancellationToken cancellationToken)
		{
			var record = await this.machineRefTeamRepository.GetMachine(id);

			return record != null;
		}

		private async Task<bool> BeValidTeam(int id,  CancellationToken cancellationToken)
		{
			var record = await this.machineRefTeamRepository.GetTeam(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d45f45ed676c85eb50fb4d9270f4e455</Hash>
</Codenesium>*/