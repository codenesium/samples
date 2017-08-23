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
	public class LinkModelValidator: LinkModelValidatorAbstract
	{
		public LinkModelValidator()
		{   }

		public void CreateMode()
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.IdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
		}

		public void UpdateMode()
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.IdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
		}

		public void PatchMode()
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.IdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
		}
	}
}

/*<Codenesium>
    <Hash>1d3c3d8c504cbf3aa5d00f026e93a10a</Hash>
</Codenesium>*/