using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class ApiDeviceRequestModelValidator: AbstractApiDeviceRequestModelValidator, IApiDeviceRequestModelValidator
	{
		public ApiDeviceRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model)
		{
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b9b0d6c198ac93c2d14a60c13d86e586</Hash>
</Codenesium>*/