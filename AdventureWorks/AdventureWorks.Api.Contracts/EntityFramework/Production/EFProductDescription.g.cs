using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductDescription", Schema="Production")]
	public partial class EFProductDescription
	{
		public EFProductDescription()
		{}

		public void SetProperties(int productDescriptionID,
		                          string description,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Description = description;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID {get; set;}

		[Column("Description", TypeName="nvarchar(400)")]
		public string Description {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>8fc15f3958f1112064aecb84057feacb</Hash>
</Codenesium>*/