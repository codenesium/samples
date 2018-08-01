using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiVariableSetRequestModelValidator : AbstractApiVariableSetRequestModelValidator, IApiVariableSetRequestModelValidator
	{
		public ApiVariableSetRequestModelValidator(IVariableSetRepository variableSetRepository)
			: base(variableSetRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVariableSetRequestModel model)
		{
			this.IsFrozenRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdsRules();
			this.VersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiVariableSetRequestModel model)
		{
			this.IsFrozenRules();
			this.JSONRules();
			this.OwnerIdRules();
			this.RelatedDocumentIdsRules();
			this.VersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2f9c69725371cd0b145997bbdc7c17b1</Hash>
</Codenesium>*/