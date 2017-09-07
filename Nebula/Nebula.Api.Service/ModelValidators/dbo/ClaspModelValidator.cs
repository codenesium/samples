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
	public class ClaspModelValidator: ClaspModelValidatorAbstract
	{
		public ClaspModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>6fe04e98a2effc54eef5bf4c41466350</Hash>
</Codenesium>*/