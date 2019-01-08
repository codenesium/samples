using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiSelfReferenceServerRequestModelValidator : AbstractApiSelfReferenceServerRequestModelValidator, IApiSelfReferenceServerRequestModelValidator
	{
		public ApiSelfReferenceServerRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
			: base(selfReferenceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceServerRequestModel model)
		{
			this.SelfReferenceIdRules();
			this.SelfReferenceId2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceServerRequestModel model)
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
    <Hash>06d0ed59312ea8987d7d5c12a66a5778</Hash>
</Codenesium>*/