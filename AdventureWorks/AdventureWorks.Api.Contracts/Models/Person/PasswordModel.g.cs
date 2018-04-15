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

		public PasswordModel(
			string passwordHash,
			string passwordSalt,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.PasswordHash = passwordHash.ToString();
			this.PasswordSalt = passwordSalt.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>7362d628a630fb2f2b7244b10a4bdaea</Hash>
</Codenesium>*/