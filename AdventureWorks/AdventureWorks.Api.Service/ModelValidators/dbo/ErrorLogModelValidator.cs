using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ErrorLogModelValidator: AbstractErrorLogModelValidator, IErrorLogModelValidator
	{
		public ErrorLogModelValidator()
		{   }

		public void CreateMode()
		{
			this.ErrorTimeRules();
			this.UserNameRules();
			this.ErrorNumberRules();
			this.ErrorSeverityRules();
			this.ErrorStateRules();
			this.ErrorProcedureRules();
			this.ErrorLineRules();
			this.ErrorMessageRules();
		}

		public void UpdateMode()
		{
			this.ErrorTimeRules();
			this.UserNameRules();
			this.ErrorNumberRules();
			this.ErrorSeverityRules();
			this.ErrorStateRules();
			this.ErrorProcedureRules();
			this.ErrorLineRules();
			this.ErrorMessageRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>b568ad5d57c5645862afb60939087882</Hash>
</Codenesium>*/