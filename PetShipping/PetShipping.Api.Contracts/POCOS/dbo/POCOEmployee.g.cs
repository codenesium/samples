using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOEmployee
	{
		public POCOEmployee()
		{}

		public POCOEmployee(
			string firstName,
			int id,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName.ToString();
		}

		public string FirstName { get; set; }
		public int Id { get; set; }
		public bool IsSalesPerson { get; set; }
		public bool IsShipper { get; set; }
		public string LastName { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue { get; set; } = true;

		public bool ShouldSerializeFirstName()
		{
			return this.ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIsSalesPersonValue { get; set; } = true;

		public bool ShouldSerializeIsSalesPerson()
		{
			return this.ShouldSerializeIsSalesPersonValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIsShipperValue { get; set; } = true;

		public bool ShouldSerializeIsShipper()
		{
			return this.ShouldSerializeIsShipperValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastNameValue { get; set; } = true;

		public bool ShouldSerializeLastName()
		{
			return this.ShouldSerializeLastNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeIsSalesPersonValue = false;
			this.ShouldSerializeIsShipperValue = false;
			this.ShouldSerializeLastNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8f631dedb1fb311e4ecf32d6e199c27c</Hash>
</Codenesium>*/