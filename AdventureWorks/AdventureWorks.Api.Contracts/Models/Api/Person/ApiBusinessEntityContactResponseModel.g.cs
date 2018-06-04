using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityContactResponseModel: AbstractApiResponseModel
	{
		public ApiBusinessEntityContactResponseModel() : base()
		{}

		public void SetProperties(
			int businessEntityID,
			int contactTypeID,
			DateTime modifiedDate,
			int personID,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public int BusinessEntityID { get; private set; }
		public int ContactTypeID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int PersonID { get; private set; }
		public Guid Rowguid { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeContactTypeIDValue { get; set; } = true;

		public bool ShouldSerializeContactTypeID()
		{
			return this.ShouldSerializeContactTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonIDValue { get; set; } = true;

		public bool ShouldSerializePersonID()
		{
			return this.ShouldSerializePersonIDValue;
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
			this.ShouldSerializeContactTypeIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePersonIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>80dde902486f4e2c462e34a6edb5a287</Hash>
</Codenesium>*/