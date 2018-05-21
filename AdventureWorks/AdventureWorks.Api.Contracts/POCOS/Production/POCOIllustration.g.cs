using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOIllustration: AbstractPOCO
	{
		public POCOIllustration() : base()
		{}

		public POCOIllustration(
			string diagram,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string Diagram { get; set; }
		public int IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDiagramValue { get; set; } = true;

		public bool ShouldSerializeDiagram()
		{
			return this.ShouldSerializeDiagramValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

		public bool ShouldSerializeIllustrationID()
		{
			return this.ShouldSerializeIllustrationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDiagramValue = false;
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>48e592d5ebd41f23f8fc646cf177c831</Hash>
</Codenesium>*/