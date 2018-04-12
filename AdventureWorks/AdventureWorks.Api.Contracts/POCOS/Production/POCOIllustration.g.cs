using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOIllustration
	{
		public POCOIllustration()
		{}

		public POCOIllustration(
			int illustrationID,
			string diagram,
			DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int IllustrationID { get; set; }
		public string Diagram { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

		public bool ShouldSerializeIllustrationID()
		{
			return this.ShouldSerializeIllustrationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDiagramValue { get; set; } = true;

		public bool ShouldSerializeDiagram()
		{
			return this.ShouldSerializeDiagramValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeDiagramValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>821428e62f6adcd71c2f9b04d08e9d7b</Hash>
</Codenesium>*/