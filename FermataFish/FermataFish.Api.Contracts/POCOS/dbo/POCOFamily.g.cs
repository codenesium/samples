using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOFamily
	{
		public POCOFamily()
		{}

		public POCOFamily(
			int id,
			string notes,
			string pcEmail,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			int studioId)
		{
			this.Notes = notes.ToString();
			this.PcEmail = pcEmail.ToString();
			this.PcFirstName = pcFirstName.ToString();
			this.PcLastName = pcLastName.ToString();
			this.PcPhone = pcPhone.ToString();

			this.Id = new ReferenceEntity<int>(id,
			                                   nameof(ApiResponse.Studios));
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         nameof(ApiResponse.Studios));
		}

		public ReferenceEntity<int> Id { get; set; }
		public string Notes { get; set; }
		public string PcEmail { get; set; }
		public string PcFirstName { get; set; }
		public string PcLastName { get; set; }
		public string PcPhone { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNotesValue { get; set; } = true;

		public bool ShouldSerializeNotes()
		{
			return this.ShouldSerializeNotesValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePcEmailValue { get; set; } = true;

		public bool ShouldSerializePcEmail()
		{
			return this.ShouldSerializePcEmailValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePcFirstNameValue { get; set; } = true;

		public bool ShouldSerializePcFirstName()
		{
			return this.ShouldSerializePcFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePcLastNameValue { get; set; } = true;

		public bool ShouldSerializePcLastName()
		{
			return this.ShouldSerializePcLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePcPhoneValue { get; set; } = true;

		public bool ShouldSerializePcPhone()
		{
			return this.ShouldSerializePcPhoneValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudioIdValue { get; set; } = true;

		public bool ShouldSerializeStudioId()
		{
			return this.ShouldSerializeStudioIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNotesValue = false;
			this.ShouldSerializePcEmailValue = false;
			this.ShouldSerializePcFirstNameValue = false;
			this.ShouldSerializePcLastNameValue = false;
			this.ShouldSerializePcPhoneValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>da76a7b9a4b1f4af45bf6845fbb35b47</Hash>
</Codenesium>*/