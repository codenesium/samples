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

                public ValidationResult Validate(ApiClientCommunicationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiClientCommunicationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IClientRepository ClientRepository { get; set; }

                public IEmployeeRepository EmployeeRepository { get; set; }

                public virtual void ClientIdRules()
                {
                        this.RuleFor(x => x.ClientId).NotNull();
                        this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
                }

                public virtual void DateCreatedRules()
                {
                        this.RuleFor(x => x.DateCreated).NotNull();
                }

                public virtual void EmployeeIdRules()
                {
                        this.RuleFor(x => x.EmployeeId).NotNull();
                        this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployee).When(x => x ?.EmployeeId != null).WithMessage("Invalid reference");
                }

                public virtual void NotesRules()
                {
                        this.RuleFor(x => x.Notes).NotNull();
                        this.RuleFor(x => x.Notes).Length(0, 2147483647);
                }

                private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.ClientRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.EmployeeRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>f12e617b8c6970d969df48fb108b1d0c</Hash>
</Codenesium>*/