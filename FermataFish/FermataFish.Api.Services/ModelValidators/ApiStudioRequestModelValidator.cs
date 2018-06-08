using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiStudioRequestModelValidator: AbstractApiStudioRequestModelValidator, IApiStudioRequestModelValidator
        {
                public ApiStudioRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model)
                {
                        this.Address1Rules();
                        this.Address2Rules();
                        this.CityRules();
                        this.NameRules();
                        this.StateIdRules();
                        this.WebsiteRules();
                        this.ZipRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model)
                {
                        this.Address1Rules();
                        this.Address2Rules();
                        this.CityRules();
                        this.NameRules();
                        this.StateIdRules();
                        this.WebsiteRules();
                        this.ZipRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>3a60790f3520d41d66053da93f6cf59b</Hash>
</Codenesium>*/