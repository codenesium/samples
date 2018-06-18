using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiProvinceRequestModelValidator: AbstractApiProvinceRequestModelValidator, IApiProvinceRequestModelValidator
        {
                public ApiProvinceRequestModelValidator(IProvinceRepository provinceRepository)
                        : base(provinceRepository)
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
    <Hash>3faea0054782d6a39213f089fcc88a34</Hash>
</Codenesium>*/