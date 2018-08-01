using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiSelfReferenceRequestModelValidator : AbstractApiSelfReferenceRequestModelValidator, IApiSelfReferenceRequestModelValidator
	{
		public ApiSelfReferenceRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
			: base(selfReferenceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceRequestModel model)
		{
			this.SelfReferenceIdRules();
			this.SelfReferenceId2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceRequestModel model)
		{
			this.SelfReferenceIdRules();
			this.SelfReferenceId2Rules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8cc1714754b3bb62c844247b2933ec1f</Hash>
</Codenesium>*/