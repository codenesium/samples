using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class DepartmentModelValidator: AbstractDepartmentModelValidator, IDepartmentModelValidator
	{
		public DepartmentModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.GroupNameRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>64dbde74d1fa2fa92142181d9c4f3487</Hash>
</Codenesium>*/