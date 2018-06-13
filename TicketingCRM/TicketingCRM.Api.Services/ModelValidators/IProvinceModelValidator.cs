using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiProvinceRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProvinceRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f789d16ac00490b9bcf263769d6b4ffe</Hash>
</Codenesium>*/