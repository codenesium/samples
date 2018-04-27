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
			this.AvailabilityRules();
			this.CostRateRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, LocationModel model)
		{
			this.AvailabilityRules();
			this.CostRateRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7d79ea6198ab1e74b46550f86c9fa5a5</Hash>
</Codenesium>*/