using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiContactTypeRequestModelValidator: AbstractApiContactTypeRequestModelValidator, IApiContactTypeRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>77296a7499b6165e4b31b86e4ef7cb5e</Hash>
</Codenesium>*/