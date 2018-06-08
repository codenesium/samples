using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOErrorLog: AbstractBusinessObject
        {
                public BOErrorLog() : base()
                {
                }

                public void SetProperties(int errorLogID,
                                          Nullable<int> errorLine,
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

                public Nullable<int> ErrorLine { get; private set; }

                public int ErrorLogID { get; private set; }

                public string ErrorMessage { get; private set; }

                public int ErrorNumber { get; private set; }

                public string ErrorProcedure { get; private set; }

                public Nullable<int> ErrorSeverity { get; private set; }

                public Nullable<int> ErrorState { get; private set; }

                public DateTime ErrorTime { get; private set; }

                public string UserName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>157b9b3f31d1406f9efc4a30f4409e5f</Hash>
</Codenesium>*/