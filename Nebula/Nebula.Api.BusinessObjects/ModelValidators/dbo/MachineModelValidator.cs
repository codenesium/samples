using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class MachineModelValidator: AbstractMachineModelValidator, IMachineModelValidator
	{
		public MachineModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(MachineModel model)
		{
			this.NameRules();
			this.MachineGuidRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, MachineModel model)
		{
			this.NameRules();
			this.MachineGuidRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>3ac3929e66c7c3f2df980e0efab62ce8</Hash>
</Codenesium>*/