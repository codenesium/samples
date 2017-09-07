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
	public class ChainModelValidator: ChainModelValidatorAbstract
	{
		public ChainModelValidator()
		{   }

		public void CreateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>46582ca11258c75957e6bceb5ced7e68</Hash>
</Codenesium>*/