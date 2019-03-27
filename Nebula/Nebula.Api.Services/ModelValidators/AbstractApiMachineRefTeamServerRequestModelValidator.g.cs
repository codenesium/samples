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
	public abstract class AbstractApiMachineRefTeamServerRequestModelValidator : AbstractValidator<ApiMachineRefTeamServerRequestModel>
	{
		private int existingRecordId;

		protected IMachineRefTeamRepository MachineRefTeamRepository { get; private set; }

		public AbstractApiMachineRefTeamServerRequestModelValidator(IMachineRefTeamRepository machineRefTeamRepository)
		{
			this.MachineRefTeamRepository = machineRefTeamRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineRefTeamServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void MachineIdRules()
		{
			this.RuleFor(x => x.MachineId).MustAsync(this.BeValidMachineByMachineId).When(x => !x?.MachineId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeamByTeamId).When(x => !x?.TeamId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidMachineByMachineId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.MachineRefTeamRepository.MachineByMachineId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTeamByTeamId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.MachineRefTeamRepository.TeamByTeamId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f0bcdf3973cc66a4433a2e969bdcdde7</Hash>
</Codenesium>*/