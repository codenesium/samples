using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Address", Schema="Person")]
	public partial class EFAddress
	{
		public EFAddress()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("AddressID", TypeName="int")]
		public int AddressID {get; set;}

		[Column("AddressLine1", TypeName="nvarchar(60)")]
		public string AddressLine1 {get; set;}

		[Column("AddressLine2", TypeName="nvarchar(60)")]
		public string AddressLine2 {get; set;}

		[Column("City", TypeName="nvarchar(30)")]
		public string City {get; set;}

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID {get; set;}

		[Column("PostalCode", TypeName="nvarchar(15)")]
		public string PostalCode {get; set;}

		[Column("SpatialLocation", TypeName="geography(-1)")]
		public object SpatialLocation {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("StateProvinceID")]
		public virtual EFStateProvince StateProvince { get; set; }
	}
}

/*<Codenesium>
    <Hash>e7682c82e411a29f69c59b87baf9a508</Hash>
</Codenesium>*/