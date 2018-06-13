using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiCustomerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a14c1477ea723d21e6b4195dad4d8870</Hash>
</Codenesium>*/