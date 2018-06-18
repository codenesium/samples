using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiClientCommunicationRequestModelValidator: AbstractValidator<ApiClientCommunicationRequestModel>
        {
                private int existingRecordId;

                IClientCommunicationRepository clientCommunicationRepository;

                public AbstractApiClientCommunicationRequestModelValidator(IClientCommunicationRepository clientCommunicationRepository)
                {
                        this.clientCommunicationRepository = clientCommunicationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiClientCommunicationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ClientIdRules()
                {
                        this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
                }

                public virtual void DateCreatedRules()
                {
                }

                public virtual void EmployeeIdRules()
                {
                        this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployee).When(x => x ?.EmployeeId != null).WithMessage("Invalid reference");
                }

                public virtual void NotesRules()
                {
                        this.RuleFor(x => x.Notes).NotNull();
                        this.RuleFor(x => x.Notes).Length(0, 2147483647);
                }

                private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.clientCommunicationRepository.GetClient(id);

                        return record != null;
                }

                private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.clientCommunicationRepository.GetEmployee(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>609662e4986dcda13ad0067c48e395e4</Hash>
</Codenesium>*/