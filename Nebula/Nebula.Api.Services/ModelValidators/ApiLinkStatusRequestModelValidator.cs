using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiLinkStatusRequestModelValidator: AbstractApiLinkStatusRequestModelValidator, IApiLinkStatusRequestModelValidator
        {
                public ApiLinkStatusRequestModelValidator(ILinkStatusRepository linkStatusRepository)
                        : base(linkStatusRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model)
                {
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
    <Hash>9793e03ec3cb6a4499a50d52cc3c0cf6</Hash>
</Codenesium>*/