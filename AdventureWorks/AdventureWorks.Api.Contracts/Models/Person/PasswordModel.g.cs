using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class PasswordModel
	{
		public PasswordModel()
		{}

		public PasswordModel(string passwordHash,
		                     string passwordSalt,
		                     Guid rowguid,
		                     DateTime modifiedDate)
		{
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public PasswordModel(POCOPassword poco)
		{
			this.PasswordHash = poco.PasswordHash;
			this.PasswordSalt = poco.PasswordSalt;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
		}

		private string _passwordHash;
		[Required]
		public string PasswordHash
		{
			get
			{
				return _passwordHash;
			}
			set
			{
				this._passwordHash = value;
			}
		}

		private string _passwordSalt;
		[Required]
		public string PasswordSalt
		{
			get
			{
				return _passwordSalt;
			}
			set
			{
				this._passwordSalt = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>40aeccad05f76cb0991cba166cdbe2cd</Hash>
</Codenesium>*/