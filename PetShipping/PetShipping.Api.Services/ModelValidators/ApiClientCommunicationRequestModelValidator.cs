using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiClientCommunicationRequestModelValidator: AbstractApiClientCommunicationRequestModelValidator, IApiClientCommunicationRequestModelValidator
        {
                public ApiClientCommunicationRequestModelValidator(IClientCommunicationRepository clientCommunicationRepository)
                        : base(clientCommunicationRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model)
                {
                        this.ClientIdRules();
                        this.DateCreatedRules();
                        this.EmployeeIdRules();
                        this.NotesRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model)
                {
                        this.ClientIdRules();
                        this.DateCreatedRules();
                        this.EmployeeIdRules();
                        this.NotesRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b4dabef56f0200edf40b8ed1f9c3e11f</Hash>
</Codenesium>*/