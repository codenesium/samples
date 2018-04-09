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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>cf1ac512b906d2c99884115446b926bd</Hash>
</Codenesium>*/