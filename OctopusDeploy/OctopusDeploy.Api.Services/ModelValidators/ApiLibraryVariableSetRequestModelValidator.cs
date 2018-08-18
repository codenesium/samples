using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiLibraryVariableSetRequestModelValidator : AbstractApiLibraryVariableSetRequestModelValidator, IApiLibraryVariableSetRequestModelValidator
	{
		public ApiLibraryVariableSetRequestModelValidator(ILibraryVariableSetRepository libraryVariableSetRepository)
			: base(libraryVariableSetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLibraryVariableSetRequestModel model)
		{
			this.ContentTypeRules();
			this.JSONRules();
			this.NameRules();
			this.VariableSetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiLibraryVariableSetRequestModel model)
		{
			this.ContentTypeRules();
			this.JSONRules();
			this.NameRules();
			this.VariableSetIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5f791c1f20d8a31f45c8943a75a117f5</Hash>
</Codenesium>*/