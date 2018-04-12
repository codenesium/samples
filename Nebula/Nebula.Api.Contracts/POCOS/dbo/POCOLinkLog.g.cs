using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOLinkLog
	{
		public POCOLinkLog()
		{}

		public POCOLinkLog(
			int id,
			int linkId,
			string log,
			DateTime dateEntered)
		{
			this.Id = id.ToInt();
			this.Log = log;
			this.DateEntered = dateEntered.ToDateTime();

			this.LinkId = new ReferenceEntity<int>(linkId,
			                                       "Link");
		}

		public int Id { get; set; }
		public ReferenceEntity<int> LinkId { get; set; }
		public string Log { get; set; }
		public DateTime DateEntered { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkIdValue { get; set; } = true;

		public bool ShouldSerializeLinkId()
		{
			return this.ShouldSerializeLinkIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLogValue { get; set; } = true;

		public bool ShouldSerializeLog()
		{
			return this.ShouldSerializeLogValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateEnteredValue { get; set; } = true;

		public bool ShouldSerializeDateEntered()
		{
			return this.ShouldSerializeDateEnteredValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLinkIdValue = false;
			this.ShouldSerializeLogValue = false;
			this.ShouldSerializeDateEnteredValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1f3829312e667c871a00d0c44ab82233</Hash>
</Codenesium>*/