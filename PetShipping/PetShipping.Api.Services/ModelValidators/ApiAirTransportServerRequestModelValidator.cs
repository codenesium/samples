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
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.IdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportServerRequestModel model)
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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>1f4d3522b589ed052695335ab600bb84</Hash>
</Codenesium>*/