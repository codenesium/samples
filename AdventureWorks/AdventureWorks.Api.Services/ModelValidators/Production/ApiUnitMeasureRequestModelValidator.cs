using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiUnitMeasureRequestModelValidator : AbstractApiUnitMeasureRequestModelValidator, IApiUnitMeasureRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>9e601263acfc93ac833515d82aa5a2f7</Hash>
</Codenesium>*/