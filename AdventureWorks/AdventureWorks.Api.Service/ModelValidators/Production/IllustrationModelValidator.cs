using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class IllustrationModelValidator: AbstractIllustrationModelValidator,IIllustrationModelValidator
	{
		public IllustrationModelValidator()
		{   }

		public void CreateMode()
		{
			this.DiagramRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DiagramRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.DiagramRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>6122702c7472d18c5c7e19df46eb325f</Hash>
</Codenesium>*/