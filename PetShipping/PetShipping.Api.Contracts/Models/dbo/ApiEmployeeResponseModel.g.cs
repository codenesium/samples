using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiEmployeeResponseModel: AbstractApiResponseModel
	{
		public ApiEmployeeResponseModel() : base()
		{}

		public void SetProperties(
			string firstName,
			int id,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName;
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
    <Hash>fe3c7b968feedfb57d74cdf5bb531f3c</Hash>
</Codenesium>*/