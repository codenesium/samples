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
		[Column("BillOfMaterialsID")]
		public virtual int BillOfMaterialsID { get; private set; }

		[Column("BOMLevel")]
		public virtual short BOMLevel { get; private set; }

		[Column("ComponentID")]
		public virtual int ComponentID { get; private set; }

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("PerAssemblyQty")]
		public virtual double PerAssemblyQty { get; private set; }

		[Column("ProductAssemblyID")]
		public virtual int? ProductAssemblyID { get; private set; }

		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[MaxLength(3)]
		[Column("UnitMeasureCode")]
		public virtual string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>864fc5a3f931e28ec85e51996b5f8fbe</Hash>
</Codenesium>*/