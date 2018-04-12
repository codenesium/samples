using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class AWBuildVersionModelValidator: AbstractAWBuildVersionModelValidator, IAWBuildVersionModelValidator
	{
		public AWBuildVersionModelValidator()
		{   }

		public void CreateMode()
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.Database_VersionRules();
			this.VersionDateRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>2abcfcabb976dffd206d628c6d37ff7a</Hash>
</Codenesium>*/