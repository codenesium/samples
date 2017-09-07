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
	public class MachineRefTeamModelValidator: MachineRefTeamModelValidatorAbstract
	{
		public MachineRefTeamModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.MachineIdRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.MachineIdRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.MachineIdRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>52eb9bc402268f2dff52989e8943cb75</Hash>
</Codenesium>*/