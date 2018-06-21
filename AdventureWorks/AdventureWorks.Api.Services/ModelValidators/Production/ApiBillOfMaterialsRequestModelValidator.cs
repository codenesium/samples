using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBillOfMaterialsRequestModelValidator : AbstractApiBillOfMaterialsRequestModelValidator, IApiBillOfMaterialsRequestModelValidator
        {
                public ApiBillOfMaterialsRequestModelValidator(IBillOfMaterialsRepository billOfMaterialsRepository)
                        : base(billOfMaterialsRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsRequestModel model)
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

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsRequestModel model)
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
    <Hash>2351c4c88b6fb7da2f91cfa637a50580</Hash>
</Codenesium>*/