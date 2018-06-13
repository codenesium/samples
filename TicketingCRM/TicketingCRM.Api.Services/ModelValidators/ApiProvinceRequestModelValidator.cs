using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiProvinceRequestModelValidator: AbstractApiProvinceRequestModelValidator, IApiProvinceRequestModelValidator
        {
                public ApiProvinceRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProvinceRequestModel model)
                {
                        this.CountryIdRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceRequestModel model)
                {
                        this.CountryIdRules();
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
    <Hash>1cedb9b1f3ce783ce9f70065f7e0d21a</Hash>
</Codenesium>*/