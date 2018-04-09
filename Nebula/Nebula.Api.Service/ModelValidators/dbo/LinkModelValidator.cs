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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>e97cb2c3c321af7230c83cf099b40d5a</Hash>
</Codenesium>*/