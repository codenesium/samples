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
                        this.RuleFor(x => x.MachineGuid).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>c48057c7dd8a98afe766fe4fe13a7941</Hash>
</Codenesium>*/