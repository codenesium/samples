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
    <Hash>1fe7fec48e1d1fa83e5e2b7716b6b0ba</Hash>
</Codenesium>*/