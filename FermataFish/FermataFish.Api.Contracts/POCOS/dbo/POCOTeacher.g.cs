using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOTeacher: AbstractPOCO
	{
		public POCOTeacher() : base()
		{}

		public POCOTeacher(
			DateTime birthday,
			string email,
			string firstName,
			int id,
			string lastName,
			string phone,
			int studioId)
		{
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Phone = phone;

			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         nameof(ApiResponse.Studios));
		}

		public DateTime Birthday { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBirthdayValue { get; set; } = true;

		public bool ShouldSerializeBirthday()
		{
			return this.ShouldSerializeBirthdayValue;
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

		[JsonIgnore]
		public bool ShouldSerializeStudioIdValue { get; set; } = true;

		public bool ShouldSerializeStudioId()
		{
			return this.ShouldSerializeStudioIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBirthdayValue = false;
			this.ShouldSerializeEmailValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializePhoneValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>0fd9e0bd3d654b646fd3abc9e4d931b9</Hash>
</Codenesium>*/