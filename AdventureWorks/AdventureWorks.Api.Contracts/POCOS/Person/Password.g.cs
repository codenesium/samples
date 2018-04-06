using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPassword
	{
		public POCOPassword()
		{}

		public POCOPassword(int businessEntityID,
		                    string passwordHash,
		                    string passwordSalt,
		                    Guid rowguid,
		                    DateTime modifiedDate)
		{
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Person");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public string PasswordHash {get; set;}
		public string PasswordSalt {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePasswordHashValue {get; set;} = true;

		public bool ShouldSerializePasswordHash()
		{
			return ShouldSerializePasswordHashValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePasswordSaltValue {get; set;} = true;

		public bool ShouldSerializePasswordSalt()
		{
			return ShouldSerializePasswordSaltValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializePasswordHashValue = false;
			this.ShouldSerializePasswordSaltValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>cf9037fc5ff6c319cd95efc2cfa9d557</Hash>
</Codenesium>*/