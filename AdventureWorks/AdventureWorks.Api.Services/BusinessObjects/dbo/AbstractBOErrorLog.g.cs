using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOErrorLog: AbstractBusinessObject
        {
                public AbstractBOErrorLog() : base()
                {
                }

                public virtual void SetProperties(int errorLogID,
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
    <Hash>9b0a1ddf0ec1cba263b2bdd1bd5659eb</Hash>
</Codenesium>*/