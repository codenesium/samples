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
        public abstract class AbstractApiAirTransportRequestModelValidator: AbstractValidator<ApiAirTransportRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiAirTransportRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiAirTransportRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IHandlerRepository HandlerRepository { get; set; }

                public virtual void FlightNumberRules()
                {
                        this.RuleFor(x => x.FlightNumber).NotNull();
                        this.RuleFor(x => x.FlightNumber).Length(0, 12);
                }

                public virtual void HandlerIdRules()
                {
                        this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
                }

                public virtual void IdRules()
                {
                }

                public virtual void LandDateRules()
                {
                }

                public virtual void PipelineStepIdRules()
                {
                }

                public virtual void TakeoffDateRules()
                {
                }

                private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.HandlerRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>b841d4a4d7c761a7038ad8d8399e5600</Hash>
</Codenesium>*/