using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class IllustrationModelValidator: AbstractIllustrationModelValidator, IIllustrationModelValidator
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
    <Hash>44449f853aa3406efed17dc8492e39a9</Hash>
</Codenesium>*/