using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiErrorLogRequestModel : AbstractApiRequestModel
        {
                public ApiErrorLogRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int? errorLine,
                        string errorMessage,
                        int errorNumber,
                        string errorProcedure,
                        int? errorSeverity,
                        int? errorState,
                        DateTime errorTime,
                        string userName)
                {
                        this.ErrorLine = errorLine;
                        this.ErrorMessage = errorMessage;
                        this.ErrorNumber = errorNumber;
                        this.ErrorProcedure = errorProcedure;
                        this.ErrorSeverity = errorSeverity;
                        this.ErrorState = errorState;
                        this.ErrorTime = errorTime;
                        this.UserName = userName;
                }

                private int? errorLine;

                public int? ErrorLine
                {
                        get
                        {
                                return this.errorLine;
                        }

                        set
                        {
                                this.errorLine = value;
                        }
                }

                private string errorMessage;

                [Required]
                public string ErrorMessage
                {
                        get
                        {
                                return this.errorMessage;
                        }

                        set
                        {
                                this.errorMessage = value;
                        }
                }

                private int errorNumber;

                [Required]
                public int ErrorNumber
                {
                        get
                        {
                                return this.errorNumber;
                        }

                        set
                        {
                                this.errorNumber = value;
                        }
                }

                private string errorProcedure;

                public string ErrorProcedure
                {
                        get
                        {
                                return this.errorProcedure;
                        }

                        set
                        {
                                this.errorProcedure = value;
                        }
                }

                private int? errorSeverity;

                public int? ErrorSeverity
                {
                        get
                        {
                                return this.errorSeverity;
                        }

                        set
                        {
                                this.errorSeverity = value;
                        }
                }

                private int? errorState;

                public int? ErrorState
                {
                        get
                        {
                                return this.errorState;
                        }

                        set
                        {
                                this.errorState = value;
                        }
                }

                private DateTime errorTime;

                [Required]
                public DateTime ErrorTime
                {
                        get
                        {
                                return this.errorTime;
                        }

                        set
                        {
                                this.errorTime = value;
                        }
                }

                private string userName;

                [Required]
                public string UserName
                {
                        get
                        {
                                return this.userName;
                        }

                        set
                        {
                                this.userName = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>8311c2fc8f54e054315a71f879a5d3e0</Hash>
</Codenesium>*/