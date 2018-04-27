using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOHandler
	{
		public POCOHandler()
		{}

		public POCOHandler(
			int countryId,
			string email,
			string firstName,
			int id,
			string lastName,
			string phone)
		{
			this.CountryId = countryId.ToInt();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
		}

		public int CountryId { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryIdValue { get; set; } = true;

		public bool ShouldSerializeCountryId()
		{
			return this.ShouldSerializeCountryIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailValue { get; set; } = true;

		public bool ShouldSerializeEmail()
		{
			return this.ShouldSerializeEmailValue;
		}

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
		public bool ShouldSerializeLastNameValue { get; set; } = true;

		public bool ShouldSerializeLastName()
		{
			return this.ShouldSerializeLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneValue { get; set; } = true;

		public bool ShouldSerializePhone()
		{
			return this.ShouldSerializePhoneValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryIdValue = false;
			this.ShouldSerializeEmailValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializePhoneValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>acfab68ad548f9daac94c13beba7b71e</Hash>
</Codenesium>*/