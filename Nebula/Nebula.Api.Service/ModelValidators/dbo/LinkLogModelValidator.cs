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
	public class LinkLogModelValidator: LinkLogModelValidatorAbstract
	{
		public LinkLogModelValidator()
		{   }

		public void CreateMode()
		{
			this.DateEnteredRules();
			this.IdRules();
			this.LinkIdRules();
			this.LogRules();
		}

		public void UpdateMode()
		{
			this.DateEnteredRules();
			this.IdRules();
			this.LinkIdRules();
			this.LogRules();
		}

		public void PatchMode()
		{
			this.DateEnteredRules();
			this.IdRules();
			this.LinkIdRules();
			this.LogRules();
		}
	}
}

/*<Codenesium>
    <Hash>f26e6f53c46c3e6e5744cdd3725144b4</Hash>
</Codenesium>*/