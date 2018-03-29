using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ErrorLogModelValidator: AbstractErrorLogModelValidator,IErrorLogModelValidator
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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>230fdd97f956ecb2e30695b55ec091e3</Hash>
</Codenesium>*/