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
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
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
    <Hash>717a7be61a3d33418d0b8a68739d76c3</Hash>
</Codenesium>*/