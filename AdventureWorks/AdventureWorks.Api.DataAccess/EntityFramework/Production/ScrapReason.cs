using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ScrapReason", Schema="Production")]
	public partial class ScrapReason: AbstractEntityFrameworkPOCO
	{
		public ScrapReason()
		{}

		public void SetProperties(
			short scrapReasonID,
			DateTime modifiedDate,
			string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ScrapReasonID = scrapReasonID;
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("ScrapReasonID", TypeName="smallint")]
		public short ScrapReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>2d7b7b49e533df4ff940824c5282c1c8</Hash>
</Codenesium>*/