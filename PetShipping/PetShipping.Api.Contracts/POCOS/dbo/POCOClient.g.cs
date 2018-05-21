using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOClient: AbstractPOCO
	{
		public POCOClient() : base()
		{}

		public POCOClient(
			string email,
			string firstName,
			int id,
			string lastName,
			string notes,
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Notes = notes;
			this.Phone = phone;
		}

		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Notes { get; set; }
		public string Phone { get; set; }

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
		public bool ShouldSerializeNotesValue { get; set; } = true;

		public bool ShouldSerializeNotes()
		{
			return this.ShouldSerializeNotesValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneValue { get; set; } = true;

		public bool ShouldSerializePhone()
		{
			return this.ShouldSerializePhoneValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeEmailValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializeNotesValue = false;
			this.ShouldSerializePhoneValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>af59ed8deead847353d370f2079cab41</Hash>
</Codenesium>*/