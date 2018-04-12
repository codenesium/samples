using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class LinkModelValidator: AbstractLinkModelValidator, ILinkModelValidator
	{
		public LinkModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.DynamicParametersRules();
			this.StaticParametersRules();
			this.ChainIdRules();
			this.AssignedMachineIdRules();
			this.LinkStatusIdRules();
			this.OrderRules();
			this.DateStartedRules();
			this.DateCompletedRules();
			this.ResponseRules();
			this.ExternalIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.DynamicParametersRules();
			this.StaticParametersRules();
			this.ChainIdRules();
			this.AssignedMachineIdRules();
			this.LinkStatusIdRules();
			this.OrderRules();
			this.DateStartedRules();
			this.DateCompletedRules();
			this.ResponseRules();
			this.ExternalIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>9cd19cf311d2c0dc6d917380b856f406</Hash>
</Codenesium>*/