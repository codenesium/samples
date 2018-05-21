using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPasswordModel: AbstractModel
	{
		public ApiPasswordModel() : base()
		{}

		public ApiPasswordModel(
			DateTime modifiedDate,
			string passwordHash,
			string passwordSalt,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid.ToGuid();
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private string passwordHash;

		[Required]
		public string PasswordHash
		{
			get
			{
				return this.passwordHash;
			}

			set
			{
				this.passwordHash = value;
			}
		}

		private string passwordSalt;

		[Required]
		public string PasswordSalt
		{
			get
			{
				return this.passwordSalt;
			}

			set
			{
				this.passwordSalt = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b72417ad750b8fa9b0625c646357aa83</Hash>
</Codenesium>*/