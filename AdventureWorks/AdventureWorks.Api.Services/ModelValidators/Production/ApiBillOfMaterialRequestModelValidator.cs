using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBillOfMaterialRequestModelValidator : AbstractApiBillOfMaterialRequestModelValidator, IApiBillOfMaterialRequestModelValidator
        {
                public ApiBillOfMaterialRequestModelValidator(IBillOfMaterialRepository billOfMaterialRepository)
                        : base(billOfMaterialRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialRequestModel model)
                {
                        this.BOMLevelRules();
                        this.ComponentIDRules();
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.PerAssemblyQtyRules();
                        this.ProductAssemblyIDRules();
                        this.StartDateRules();
                        this.UnitMeasureCodeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialRequestModel model)
                {
                        this.BOMLevelRules();
                        this.ComponentIDRules();
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.PerAssemblyQtyRules();
                        this.ProductAssemblyIDRules();
                        this.StartDateRules();
                        this.UnitMeasureCodeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c0d860b0ed5db36ac6a6786bafb7ff3d</Hash>
</Codenesium>*/