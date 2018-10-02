using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiLocationRequestModelValidator : AbstractApiLocationRequestModelValidator, IApiLocationRequestModelValidator
	{
		public ApiLocationRequestModelValidator(ILocationRepository locationRepository)
			: base(locationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model)
		{
			this.GpsLatRules();
			this.GpsLongRules();
			this.LocationNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLocationRequestModel model)
		{
			this.GpsLatRules();
			this.GpsLongRules();
			this.LocationNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>27b2bc09cd84ffaf4ff40a6400113cf4</Hash>
</Codenesium>*/