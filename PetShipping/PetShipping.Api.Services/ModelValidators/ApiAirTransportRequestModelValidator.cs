using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiAirTransportRequestModelValidator: AbstractApiAirTransportRequestModelValidator, IApiAirTransportRequestModelValidator
	{
		public ApiAirTransportRequestModelValidator()
		{   }

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
    <Hash>02696b982601d1d72f0c4d103d60c042</Hash>
</Codenesium>*/