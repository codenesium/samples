using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiMachineRefTeamRequestModelValidator: AbstractApiMachineRefTeamRequestModelValidator, IApiMachineRefTeamRequestModelValidator
	{
		public ApiMachineRefTeamRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamRequestModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamRequestModel model)
		{
			this.MachineIdRules();
			this.TeamIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e357f01569ce651e86b6ee2822668d5b</Hash>
</Codenesium>*/