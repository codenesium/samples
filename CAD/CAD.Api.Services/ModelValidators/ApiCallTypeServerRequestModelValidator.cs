using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallTypeServerRequestModelValidator : AbstractApiCallTypeServerRequestModelValidator, IApiCallTypeServerRequestModelValidator
	{
		public ApiCallTypeServerRequestModelValidator(ICallTypeRepository callTypeRepository)
			: base(callTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>05d65381f0487ca86b16b72b91e5c4af</Hash>
</Codenesium>*/