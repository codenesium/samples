using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class EmployeeDepartmentHistoryModelValidator: AbstractEmployeeDepartmentHistoryModelValidator, IEmployeeDepartmentHistoryModelValidator
	{
		public EmployeeDepartmentHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.DepartmentIDRules();
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DepartmentIDRules();
			this.ShiftIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>1942cb83411106a79073488812cb37eb</Hash>
</Codenesium>*/