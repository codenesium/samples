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

                public ValidationResult Validate(ApiMachineRefTeamRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiMachineRefTeamRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IMachineRepository MachineRepository { get; set; }

                public ITeamRepository TeamRepository { get; set; }

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
                        var record = await this.MachineRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidTeam(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.TeamRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>9bb98672e2a240896baa4315554d483e</Hash>
</Codenesium>*/