using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBusinessEntityContactRequestModelValidator: AbstractApiBusinessEntityContactRequestModelValidator, IApiBusinessEntityContactRequestModelValidator
        {
                public ApiBusinessEntityContactRequestModelValidator(IBusinessEntityContactRepository businessEntityContactRepository)
                        : base(businessEntityContactRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model)
                {
                        this.ContactTypeIDRules();
                        this.ModifiedDateRules();
                        this.PersonIDRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model)
                {
                        this.ContactTypeIDRules();
                        this.ModifiedDateRules();
                        this.PersonIDRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2ced83513b0ef7942f53cb7265e01b04</Hash>
</Codenesium>*/