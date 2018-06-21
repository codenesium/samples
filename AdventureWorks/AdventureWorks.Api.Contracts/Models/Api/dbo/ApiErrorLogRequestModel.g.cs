using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
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
                        this.ErrorMessage = errorMessage;
                        this.ErrorNumber = errorNumber;
                        this.ErrorProcedure = errorProcedure;
                        this.ErrorSeverity = errorSeverity;
                        this.ErrorState = errorState;
                        this.ErrorTime = errorTime;
                        this.UserName = userName;
                }

                private Nullable<int> errorLine;

                public Nullable<int> ErrorLine
                {
                        get
                        {
                                return this.errorLine.IsEmptyOrZeroOrNull() ? null : this.errorLine;
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
                                return this.errorProcedure.IsEmptyOrZeroOrNull() ? null : this.errorProcedure;
                        }

                        set
                        {
                                this.errorProcedure = value;
                        }
                }

                private Nullable<int> errorSeverity;

                public Nullable<int> ErrorSeverity
                {
                        get
                        {
                                return this.errorSeverity.IsEmptyOrZeroOrNull() ? null : this.errorSeverity;
                        }

                        set
                        {
                                this.errorSeverity = value;
                        }
                }

                private Nullable<int> errorState;

                public Nullable<int> ErrorState
                {
                        get
                        {
                                return this.errorState.IsEmptyOrZeroOrNull() ? null : this.errorState;
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
    <Hash>354759728dd5933b7b8a8dd78461ef7a</Hash>
</Codenesium>*/