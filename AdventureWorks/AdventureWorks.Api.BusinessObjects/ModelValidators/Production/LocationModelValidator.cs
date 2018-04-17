using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class LocationModelValidator: AbstractLocationModelValidator, ILocationModelValidator
	{
		public LocationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LocationModel model)
		{
			this.NameRules();
			this.CostRateRules();
			this.AvailabilityRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, LocationModel model)
		{
			this.NameRules();
			this.CostRateRules();
			this.AvailabilityRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f1d6a0251dc6a8e6fd2dc6734c386f9d</Hash>
</Codenesium>*/