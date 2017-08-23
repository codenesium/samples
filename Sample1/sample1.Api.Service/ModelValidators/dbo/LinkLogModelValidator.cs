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
    <Hash>5c3e443778c77dd07f5a260a8549e794</Hash>
</Codenesium>*/