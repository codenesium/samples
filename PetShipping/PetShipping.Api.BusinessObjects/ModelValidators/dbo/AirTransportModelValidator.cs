using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class AirTransportModelValidator: AbstractAirTransportModelValidator, IAirTransportModelValidator
	{
		public AirTransportModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AirTransportModel model)
		{
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.IdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AirTransportModel model)
		{
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.IdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>37b634e4eb8bcb87b3565d2a40232953</Hash>
</Codenesium>*/