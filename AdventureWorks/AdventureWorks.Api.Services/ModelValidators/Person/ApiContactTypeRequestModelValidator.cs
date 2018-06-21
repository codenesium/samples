using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiContactTypeRequestModelValidator : AbstractApiContactTypeRequestModelValidator, IApiContactTypeRequestModelValidator
        {
                public ApiContactTypeRequestModelValidator(IContactTypeRepository contactTypeRepository)
                        : base(contactTypeRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>8950601db5c3a8d5084221dddb46738a</Hash>
</Codenesium>*/