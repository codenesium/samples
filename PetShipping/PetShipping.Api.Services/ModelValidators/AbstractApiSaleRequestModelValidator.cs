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
        public abstract class AbstractApiSaleRequestModelValidator: AbstractValidator<ApiSaleRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSaleRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IClientRepository ClientRepository { get; set; }

                public IPetRepository PetRepository { get; set; }

                public virtual void AmountRules()
                {
                        this.RuleFor(x => x.Amount).NotNull();
                }

                public virtual void ClientIdRules()
                {
                        this.RuleFor(x => x.ClientId).NotNull();
                        this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
                }

                public virtual void NoteRules()
                {
                        this.RuleFor(x => x.Note).NotNull();
                        this.RuleFor(x => x.Note).Length(0, 2147483647);
                }

                public virtual void PetIdRules()
                {
                        this.RuleFor(x => x.PetId).NotNull();
                        this.RuleFor(x => x.PetId).MustAsync(this.BeValidPet).When(x => x ?.PetId != null).WithMessage("Invalid reference");
                }

                public virtual void SaleDateRules()
                {
                        this.RuleFor(x => x.SaleDate).NotNull();
                }

                public virtual void SalesPersonIdRules()
                {
                        this.RuleFor(x => x.SalesPersonId).NotNull();
                }

                private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.ClientRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidPet(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.PetRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>fa3a3147fa8697a8d46a9da81732f34c</Hash>
</Codenesium>*/