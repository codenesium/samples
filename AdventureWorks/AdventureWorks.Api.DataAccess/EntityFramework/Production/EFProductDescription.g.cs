using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDescription", Schema="Production")]
	public partial class EFProductDescription: AbstractEntityFrameworkPOCO
	{
		public EFProductDescription()
		{}

		public void SetProperties(
			int productDescriptionID,
			string description,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Description = description.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID { get; set; }

		[Column("Description", TypeName="nvarchar(400)")]
		public string Description { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>02609e47eafc17ddf2bf5c464d30f491</Hash>
</Codenesium>*/