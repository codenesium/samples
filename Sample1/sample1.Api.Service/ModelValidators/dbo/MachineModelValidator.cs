using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;

namespace sample1NS.Api.Service
{
	public class MachineModelValidator: MachineModelValidatorAbstract
	{
		public MachineModelValidator()
		{   }

		public void CreateMode()
		{
			this.DescriptionRules();
			this.IdRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.DescriptionRules();
			this.IdRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.DescriptionRules();
			this.IdRules();
			this.JwtKeyRules();
			this.LastIpAddressRules();
			this.MachineGuidRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>50224cc2e1b4adf8e51f46dd6b7ffa14</Hash>
</Codenesium>*/