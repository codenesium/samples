using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>e37f903c006dda69037564c197075427</Hash>
</Codenesium>*/