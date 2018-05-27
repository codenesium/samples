using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiMachineRequestModelValidator: AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
	{
		public ApiMachineRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>ae1378dceeedf82e1e8f51bdf153e5c3</Hash>
</Codenesium>*/