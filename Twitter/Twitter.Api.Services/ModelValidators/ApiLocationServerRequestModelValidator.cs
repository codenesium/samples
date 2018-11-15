using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiLocationServerRequestModelValidator : AbstractApiLocationServerRequestModelValidator, IApiLocationServerRequestModelValidator
	{
		public ApiLocationServerRequestModelValidator(ILocationRepository locationRepository)
			: base(locationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLocationServerRequestModel model)
		{
			this.GpsLatRules();
			this.GpsLongRules();
			this.LocationNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLocationServerRequestModel model)
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
    <Hash>38920d25db8e301f7d1e4904b7e3d8d1</Hash>
</Codenesium>*/