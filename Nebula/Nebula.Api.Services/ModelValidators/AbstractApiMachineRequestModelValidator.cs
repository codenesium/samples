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
                        this.RuleFor(x => x.Description).Length(0, 2147483647);
                }

                public virtual void JwtKeyRules()
                {
                        this.RuleFor(x => x.JwtKey).Length(0, 128);
                }

                public virtual void LastIpAddressRules()
                {
                        this.RuleFor(x => x.LastIpAddress).Length(0, 128);
                }

                public virtual void MachineGuidRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>be5824d78d942f4dd72c3fb75d973737</Hash>
</Codenesium>*/