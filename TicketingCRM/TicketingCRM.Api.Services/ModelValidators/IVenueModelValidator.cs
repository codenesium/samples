using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiVenueRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVenueRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>694f651a5b6b4477afff711d2ee49d21</Hash>
</Codenesium>*/