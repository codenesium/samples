using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiUnitMeasureRequestModelValidator: AbstractApiUnitMeasureRequestModelValidator, IApiUnitMeasureRequestModelValidator
        {
                public ApiUnitMeasureRequestModelValidator(IUnitMeasureRepository unitMeasureRepository)
                        : base(unitMeasureRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b4db7b24247d17b924babfebd006b85f</Hash>
</Codenesium>*/