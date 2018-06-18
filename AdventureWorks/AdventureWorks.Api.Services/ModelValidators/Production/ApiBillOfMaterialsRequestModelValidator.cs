using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBillOfMaterialsRequestModelValidator: AbstractApiBillOfMaterialsRequestModelValidator, IApiBillOfMaterialsRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>27d9d1687dbfa918a708be39f7fcf5d1</Hash>
</Codenesium>*/