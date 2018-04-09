using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductCategory", Schema="Production")]
	public partial class EFProductCategory
	{
		public EFProductCategory()
		{}

		public void SetProperties(int productCategoryID,
		                          string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>574e06565ab2390c3631fc140ac5e769</Hash>
</Codenesium>*/