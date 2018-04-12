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
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			string pcEmail,
			string notes,
			int studioId)
		{
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.PcEmail = pcEmail;
			this.Notes = notes;

			this.Id = new ReferenceEntity<int>(id,
			                                   "Studio");
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         "Studio");
		}

		public ReferenceEntity<int> Id { get; set; }
		public string PcFirstName { get; set; }
		public string PcLastName { get; set; }
		public string PcPhone { get; set; }
		public string PcEmail { get; set; }
		public string Notes { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
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
		public bool ShouldSerializePcEmailValue { get; set; } = true;

		public bool ShouldSerializePcEmail()
		{
			return this.ShouldSerializePcEmailValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNotesValue { get; set; } = true;

		public bool ShouldSerializeNotes()
		{
			return this.ShouldSerializeNotesValue;
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
			this.ShouldSerializePcFirstNameValue = false;
			this.ShouldSerializePcLastNameValue = false;
			this.ShouldSerializePcPhoneValue = false;
			this.ShouldSerializePcEmailValue = false;
			this.ShouldSerializeNotesValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d73f5a20a48b430e28558a89a4fc6d2f</Hash>
</Codenesium>*/