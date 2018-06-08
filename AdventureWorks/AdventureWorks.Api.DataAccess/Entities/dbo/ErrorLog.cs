using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ErrorLog", Schema="dbo")]
        public partial class ErrorLog: AbstractEntity
        {
                public ErrorLog()
                {
                }

                public void SetProperties(
                        Nullable<int> errorLine,
                        int errorLogID,
                        string errorMessage,
                        int errorNumber,
                        string errorProcedure,
                        Nullable<int> errorSeverity,
                        Nullable<int> errorState,
                        DateTime errorTime,
                        string userName)
                {
                        this.ErrorLine = errorLine;
                        this.ErrorLogID = errorLogID;
                        this.ErrorMessage = errorMessage;
                        this.ErrorNumber = errorNumber;
                        this.ErrorProcedure = errorProcedure;
                        this.ErrorSeverity = errorSeverity;
                        this.ErrorState = errorState;
                        this.ErrorTime = errorTime;
                        this.UserName = userName;
                }

                [Column("ErrorLine", TypeName="int")]
                public Nullable<int> ErrorLine { get; private set; }

                [Key]
                [Column("ErrorLogID", TypeName="int")]
                public int ErrorLogID { get; private set; }

                [Column("ErrorMessage", TypeName="nvarchar(4000)")]
                public string ErrorMessage { get; private set; }

                [Column("ErrorNumber", TypeName="int")]
                public int ErrorNumber { get; private set; }

                [Column("ErrorProcedure", TypeName="nvarchar(126)")]
                public string ErrorProcedure { get; private set; }

                [Column("ErrorSeverity", TypeName="int")]
                public Nullable<int> ErrorSeverity { get; private set; }

                [Column("ErrorState", TypeName="int")]
                public Nullable<int> ErrorState { get; private set; }

                [Column("ErrorTime", TypeName="datetime")]
                public DateTime ErrorTime { get; private set; }

                [Column("UserName", TypeName="nvarchar(128)")]
                public string UserName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0a433adacee3ed2f0116f328d2f8de4e</Hash>
</Codenesium>*/