using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiAirTransportRequestModelValidator: AbstractApiAirTransportRequestModelValidator, IApiAirTransportRequestModelValidator
        {
                public ApiAirTransportRequestModelValidator(IAirTransportRepository airTransportRepository)
                        : base(airTransportRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model)
                {
                        this.FlightNumberRules();
                        this.HandlerIdRules();
                        this.IdRules();
                        this.LandDateRules();
                        this.PipelineStepIdRules();
                        this.TakeoffDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model)
                {
                        this.FlightNumberRules();
                        this.HandlerIdRules();
                        this.IdRules();
                        this.LandDateRules();
                        this.PipelineStepIdRules();
                        this.TakeoffDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>8dd2cd21340f15959e4e81a787638f94</Hash>
</Codenesium>*/