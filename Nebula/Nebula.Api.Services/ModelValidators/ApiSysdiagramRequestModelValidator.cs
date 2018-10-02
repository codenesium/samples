using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiSysdiagramRequestModelValidator : AbstractApiSysdiagramRequestModelValidator, IApiSysdiagramRequestModelValidator
	{
		public ApiSysdiagramRequestModelValidator(ISysdiagramRepository sysdiagramRepository)
			: base(sysdiagramRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSysdiagramRequestModel model)
		{
			this.DefinitionRules();
			this.NameRules();
			this.PrincipalIdRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSysdiagramRequestModel model)
		{
			this.DefinitionRules();
			this.NameRules();
			this.PrincipalIdRules();
			this.VersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>b9ac65ebe672c8d33d89a8605270c980</Hash>
</Codenesium>*/