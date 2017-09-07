using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
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
    <Hash>7d7f5b3b9039aacfcc6e0f43653f3176</Hash>
</Codenesium>*/