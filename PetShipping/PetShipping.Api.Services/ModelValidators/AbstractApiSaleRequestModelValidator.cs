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

                ISaleRepository saleRepository;

                public AbstractApiSaleRequestModelValidator(ISaleRepository saleRepository)
                {
                        this.saleRepository = saleRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AmountRules()
                {
                }

                public virtual void ClientIdRules()
                {
                        this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
                }

                public virtual void NoteRules()
                {
                        this.RuleFor(x => x.Note).NotNull();
                        this.RuleFor(x => x.Note).Length(0, 2147483647);
                }

                public virtual void PetIdRules()
                {
                        this.RuleFor(x => x.PetId).MustAsync(this.BeValidPet).When(x => x ?.PetId != null).WithMessage("Invalid reference");
                }

                public virtual void SaleDateRules()
                {
                }

                public virtual void SalesPersonIdRules()
                {
                }

                private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.saleRepository.GetClient(id);

                        return record != null;
                }

                private async Task<bool> BeValidPet(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.saleRepository.GetPet(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>1e5fa329a5034f5bd33e8ea36c87705f</Hash>
</Codenesium>*/