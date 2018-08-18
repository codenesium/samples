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
    <Hash>ef522a9d44386f9bc57cd1beb213fd88</Hash>
</Codenesium>*/