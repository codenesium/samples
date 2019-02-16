using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ErrorLog", Schema="dbo")]
	public partial class ErrorLog : AbstractEntity
	{
		public ErrorLog()
		{
		}

		public virtual void SetProperties(
			int errorLogID,
			int? errorLine,
			string errorMessage,
			int errorNumber,
			string errorProcedure,
			int? errorSeverity,
			int? errorState,
			DateTime errorTime,
			string userName)
		{
			this.ErrorLogID = errorLogID;
			this.ErrorLine = errorLine;
			this.ErrorMessage = errorMessage;
			this.ErrorNumber = errorNumber;
			this.ErrorProcedure = errorProcedure;
			this.ErrorSeverity = errorSeverity;
			this.ErrorState = errorState;
			this.ErrorTime = errorTime;
			this.UserName = userName;
		}

		[Column("ErrorLine")]
		public virtual int? ErrorLine { get; private set; }

		[Key]
		[Column("ErrorLogID")]
		public virtual int ErrorLogID { get; private set; }

		[MaxLength(4000)]
		[Column("ErrorMessage")]
		public virtual string ErrorMessage { get; private set; }

		[Column("ErrorNumber")]
		public virtual int ErrorNumber { get; private set; }

		[MaxLength(126)]
		[Column("ErrorProcedure")]
		public virtual string ErrorProcedure { get; private set; }

		[Column("ErrorSeverity")]
		public virtual int? ErrorSeverity { get; private set; }

		[Column("ErrorState")]
		public virtual int? ErrorState { get; private set; }

		[Column("ErrorTime")]
		public virtual DateTime ErrorTime { get; private set; }

		[MaxLength(128)]
		[Column("UserName")]
		public virtual string UserName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>11b0d939dce3eafcc877b2866f39473d</Hash>
</Codenesium>*/