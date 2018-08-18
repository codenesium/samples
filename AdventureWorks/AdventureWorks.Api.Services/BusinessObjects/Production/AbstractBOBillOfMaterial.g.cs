using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOBillOfMaterial : AbstractBusinessObject
	{
		public AbstractBOBillOfMaterial()
			: base()
		{
		}

		public virtual void SetProperties(int billOfMaterialsID,
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

		public int BillOfMaterialsID { get; private set; }

		public short BOMLevel { get; private set; }

		public int ComponentID { get; private set; }

		public DateTime? EndDate { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public double PerAssemblyQty { get; private set; }

		public int? ProductAssemblyID { get; private set; }

		public DateTime StartDate { get; private set; }

		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6cb03d19ec27e031c0ff98bba6421445</Hash>
</Codenesium>*/