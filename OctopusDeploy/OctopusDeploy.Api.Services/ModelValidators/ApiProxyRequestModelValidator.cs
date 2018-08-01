using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiProxyRequestModelValidator : AbstractApiProxyRequestModelValidator, IApiProxyRequestModelValidator
	{
		public ApiProxyRequestModelValidator(IProxyRepository proxyRepository)
			: base(proxyRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProxyRequestModel model)
		{
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProxyRequestModel model)
		{
			this.JSONRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d7187f7003a56bcb95324e4ccf97ab06</Hash>
</Codenesium>*/