using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>c882e2b329697eee06bc37994897a45f</Hash>
</Codenesium>*/