using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ErrorLogModel
	{
		public ErrorLogModel()
		{}
		public ErrorLogModel(DateTime errorTime,
		                     string userName,
		                     int errorNumber,
		                     Nullable<int> errorSeverity,
		                     Nullable<int> errorState,
		                     string errorProcedure,
		                     Nullable<int> errorLine,
		                     string errorMessage)
		{
			this.ErrorTime = errorTime.ToDateTime();
			this.UserName = userName;
			this.ErrorNumber = errorNumber.ToInt();
			this.ErrorSeverity = errorSeverity.ToNullableInt();
			this.ErrorState = errorState.ToNullableInt();
			this.ErrorProcedure = errorProcedure;
			this.ErrorLine = errorLine.ToNullableInt();
			this.ErrorMessage = errorMessage;
		}

		private DateTime _errorTime;
		[Required]
		public DateTime ErrorTime
		{
			get
			{
				return _errorTime;
			}
			set
			{
				this._errorTime = value;
			}
		}

		private string _userName;
		[Required]
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				this._userName = value;
			}
		}

		private int _errorNumber;
		[Required]
		public int ErrorNumber
		{
			get
			{
				return _errorNumber;
			}
			set
			{
				this._errorNumber = value;
			}
		}

		private Nullable<int> _errorSeverity;
		public Nullable<int> ErrorSeverity
		{
			get
			{
				return _errorSeverity.IsEmptyOrZeroOrNull() ? null : _errorSeverity;
			}
			set
			{
				this._errorSeverity = value;
			}
		}

		private Nullable<int> _errorState;
		public Nullable<int> ErrorState
		{
			get
			{
				return _errorState.IsEmptyOrZeroOrNull() ? null : _errorState;
			}
			set
			{
				this._errorState = value;
			}
		}

		private string _errorProcedure;
		public string ErrorProcedure
		{
			get
			{
				return _errorProcedure.IsEmptyOrZeroOrNull() ? null : _errorProcedure;
			}
			set
			{
				this._errorProcedure = value;
			}
		}

		private Nullable<int> _errorLine;
		public Nullable<int> ErrorLine
		{
			get
			{
				return _errorLine.IsEmptyOrZeroOrNull() ? null : _errorLine;
			}
			set
			{
				this._errorLine = value;
			}
		}

		private string _errorMessage;
		[Required]
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				this._errorMessage = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>100490c9456ecd6713948480744f8932</Hash>
</Codenesium>*/