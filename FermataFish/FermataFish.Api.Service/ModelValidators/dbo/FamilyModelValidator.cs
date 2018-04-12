using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class FamilyModelValidator: AbstractFamilyModelValidator, IFamilyModelValidator
	{
		public FamilyModelValidator()
		{   }

		public void CreateMode()
		{
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.PcEmailRules();
			this.NotesRules();
			this.StudioIdRules();
		}

		public void UpdateMode()
		{
			this.PcFirstNameRules();
			this.PcLastNameRules();
			this.PcPhoneRules();
			this.PcEmailRules();
			this.NotesRules();
			this.StudioIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>caadfbc90bf637f0c8e5c441eddd3604</Hash>
</Codenesium>*/