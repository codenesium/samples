using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiMachineServerRequestModelValidator : AbstractApiMachineServerRequestModelValidator, IApiMachineServerRequestModelValidator
	{
		public ApiMachineServerRequestModelValidator(IMachineRepository machineRepository)
			: base(machineRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMachineServerRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineServerRequestModel model)
		{
			this.DescriptionRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
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
    <Hash>b4503bcb75e0939f81f4f4d60661088e</Hash>
</Codenesium>*/