using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPassword
	{
		public POCOPassword()
		{}

		public POCOPassword(
			int businessEntityID,
			DateTime modifiedDate,
			string passwordHash,
			string passwordSalt,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PasswordHash = passwordHash.ToString();
			this.PasswordSalt = passwordSalt.ToString();
			this.Rowguid = rowguid.ToGuid();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.People));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
		public Guid Rowguid { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePasswordHashValue { get; set; } = true;

		public bool ShouldSerializePasswordHash()
		{
			return this.ShouldSerializePasswordHashValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePasswordSaltValue { get; set; } = true;

		public bool ShouldSerializePasswordSalt()
		{
			return this.ShouldSerializePasswordSaltValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePasswordHashValue = false;
			this.ShouldSerializePasswordSaltValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8904ad8a48d0af2dd101346887b32835</Hash>
</Codenesium>*/