using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiAirTransportServerRequestModelValidator : AbstractApiAirTransportServerRequestModelValidator, IApiAirTransportServerRequestModelValidator
	{
		public ApiAirTransportServerRequestModelValidator(IAirTransportRepository airTransportRepository)
			: base(airTransportRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirTransportServerRequestModel model)
		{
			this.AirlineIdRules();
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportServerRequestModel model)
		{
			this.AirlineIdRules();
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dc1b3d452ea6319a20174b6c9d71504e</Hash>
</Codenesium>*/