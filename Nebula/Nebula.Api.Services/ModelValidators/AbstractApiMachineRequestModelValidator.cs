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
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>86ff3f2b1c26a376104c1240389bb788</Hash>
</Codenesium>*/