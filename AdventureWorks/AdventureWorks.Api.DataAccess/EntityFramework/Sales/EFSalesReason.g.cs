using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesReason", Schema="Sales")]
	public partial class EFSalesReason
	{
		public EFSalesReason()
		{}

		public void SetProperties(
			int salesReasonID,
			string name,
			string reasonType,
			DateTime modifiedDate)
		{
			this.SalesReasonID = salesReasonID.ToInt();
			this.Name = name.ToString();
			this.ReasonType = reasonType.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ReasonType", TypeName="nvarchar(50)")]
		public string ReasonType { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>4b875598871153d5e47a6fe915b24993</Hash>
</Codenesium>*/