using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class AirlineModelValidator: AbstractAirlineModelValidator, IAirlineModelValidator
	{
		public AirlineModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AirlineModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AirlineModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0c21ccd8a9432d3a1312e266af767b0c</Hash>
</Codenesium>*/