using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class BillOfMaterial : AbstractEntity
	{
		public BillOfMaterial()
		{
		}

		public virtual void SetProperties(
			int billOfMaterialsID,
			short bOMLevel,
			int componentID,
			DateTime? endDate,
			DateTime modifiedDate,
			double perAssemblyQty,
			int? productAssemblyID,
			DateTime startDate,
			string unitMeasureCode)
		{
			this.BillOfMaterialsID = billOfMaterialsID;
			this.BOMLevel = bOMLevel;
			this.ComponentID = componentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.PerAssemblyQty = perAssemblyQty;
			this.ProductAssemblyID = productAssemblyID;
			this.StartDate = startDate;
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BillOfMaterialsID")]
		public int BillOfMaterialsID { get; private set; }

		[Column("BOMLevel")]
		public short BOMLevel { get; private set; }

		[Column("ComponentID")]
		public int ComponentID { get; private set; }

		[Column("EndDate")]
		public DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PerAssemblyQty")]
		public double PerAssemblyQty { get; private set; }

		[Column("ProductAssemblyID")]
		public int? ProductAssemblyID { get; private set; }

		[Column("StartDate")]
		public DateTime StartDate { get; private set; }

		[MaxLength(3)]
		[Column("UnitMeasureCode")]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>405057e50db592360a94054a0ac55243</Hash>
</Codenesium>*/