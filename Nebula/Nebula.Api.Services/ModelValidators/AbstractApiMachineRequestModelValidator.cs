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
        public abstract class AbstractApiMachineRequestModelValidator: AbstractValidator<ApiMachineRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiMachineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
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
    <Hash>3502621d058ad0847b6e95ca91dd122f</Hash>
</Codenesium>*/