using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesReason", Schema="Sales")]
	public partial class SalesReason: AbstractEntityFrameworkPOCO
	{
		public SalesReason()
		{}

		public void SetProperties(
			int salesReasonID,
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ReasonType = reasonType;
			this.SalesReasonID = salesReasonID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ReasonType", TypeName="nvarchar(50)")]
		public string ReasonType { get; set; }

		[Key]
		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>75184cce303acb7312dc800e3802e264</Hash>
</Codenesium>*/