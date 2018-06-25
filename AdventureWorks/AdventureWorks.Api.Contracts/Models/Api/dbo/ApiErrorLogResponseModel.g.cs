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
                        int? errorLine,
                        int errorLogID,
                        string errorMessage,
                        int errorNumber,
                        string errorProcedure,
                        int? errorSeverity,
                        int? errorState,
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

                public int? ErrorLine { get; private set; }

                public int ErrorLogID { get; private set; }

                public string ErrorMessage { get; private set; }

                public int ErrorNumber { get; private set; }

                public string ErrorProcedure { get; private set; }

                public int? ErrorSeverity { get; private set; }

                public int? ErrorState { get; private set; }

                public DateTime ErrorTime { get; private set; }

                public string UserName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeErrorLineValue { get; set; } = true;

                public bool ShouldSerializeErrorLine()
                {
                        return this.ShouldSerializeErrorLineValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorLogIDValue { get; set; } = true;

                public bool ShouldSerializeErrorLogID()
                {
                        return this.ShouldSerializeErrorLogIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorMessageValue { get; set; } = true;

                public bool ShouldSerializeErrorMessage()
                {
                        return this.ShouldSerializeErrorMessageValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorNumberValue { get; set; } = true;

                public bool ShouldSerializeErrorNumber()
                {
                        return this.ShouldSerializeErrorNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorProcedureValue { get; set; } = true;

                public bool ShouldSerializeErrorProcedure()
                {
                        return this.ShouldSerializeErrorProcedureValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorSeverityValue { get; set; } = true;

                public bool ShouldSerializeErrorSeverity()
                {
                        return this.ShouldSerializeErrorSeverityValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorStateValue { get; set; } = true;

                public bool ShouldSerializeErrorState()
                {
                        return this.ShouldSerializeErrorStateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeErrorTimeValue { get; set; } = true;

                public bool ShouldSerializeErrorTime()
                {
                        return this.ShouldSerializeErrorTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUserNameValue { get; set; } = true;

                public bool ShouldSerializeUserName()
                {
                        return this.ShouldSerializeUserNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeErrorLineValue = false;
                        this.ShouldSerializeErrorLogIDValue = false;
                        this.ShouldSerializeErrorMessageValue = false;
                        this.ShouldSerializeErrorNumberValue = false;
                        this.ShouldSerializeErrorProcedureValue = false;
                        this.ShouldSerializeErrorSeverityValue = false;
                        this.ShouldSerializeErrorStateValue = false;
                        this.ShouldSerializeErrorTimeValue = false;
                        this.ShouldSerializeUserNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>95a4db0256c8d17632db3203a2cb402a</Hash>
</Codenesium>*/