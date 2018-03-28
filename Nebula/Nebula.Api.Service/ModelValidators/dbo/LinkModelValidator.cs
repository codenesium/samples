using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public class LinkModelValidator: AbstractLinkModelValidator,ILinkModelValidator
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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>63e7bc18c5ebcaad3916068b20fdf7b2</Hash>
</Codenesium>*/