using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiMachineRefTeamRequestModelValidator: AbstractValidator<ApiMachineRefTeamRequestModel>
        {
                private int existingRecordId;

                IMachineRefTeamRepository machineRefTeamRepository;

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
                        this.RuleFor(x => x.MachineId).MustAsync(this.BeValidMachine).When(x => x ?.MachineId != null).WithMessage("Invalid reference");
                }

                public virtual void TeamIdRules()
                {
                        this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
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
    <Hash>ffd439a7791aa091e162824e5e7b4d07</Hash>
</Codenesium>*/