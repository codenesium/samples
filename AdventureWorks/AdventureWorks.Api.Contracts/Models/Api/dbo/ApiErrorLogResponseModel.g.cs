using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiErrorLogResponseModel : AbstractApiResponseModel
        {
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

                public int? ErrorLine { get; private set; }

                public int ErrorLogID { get; private set; }

                public string ErrorMessage { get; private set; }

                public int ErrorNumber { get; private set; }

                public string ErrorProcedure { get; private set; }

                public int? ErrorSeverity { get; private set; }

                public int? ErrorState { get; private set; }

                public DateTime ErrorTime { get; private set; }

                public string UserName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3a256a9ccc00f4940c01344cad7553c5</Hash>
</Codenesium>*/