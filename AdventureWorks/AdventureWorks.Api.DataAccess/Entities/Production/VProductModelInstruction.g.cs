using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vProductModelInstructions", Schema="Production")]
	public partial class VProductModelInstruction : AbstractEntity
	{
		public VProductModelInstruction()
		{
		}

		public virtual void SetProperties(
			string instruction,
			double? laborHour,
			int? locationID,
			int? lotSize,
			double? machineHour,
			DateTime modifiedDate,
			string name,
			int productModelID,
			Guid rowguid,
			double? setupHour,
			string step)
		{
			this.Instruction = instruction;
			this.LaborHour = laborHour;
			this.LocationID = locationID;
			this.LotSize = lotSize;
			this.MachineHour = machineHour;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductModelID = productModelID;
			this.Rowguid = rowguid;
			this.SetupHour = setupHour;
			this.Step = step;
		}

		[Column("Instructions")]
		public string Instruction { get; private set; }

		[Column("LaborHours")]
		public double? LaborHour { get; private set; }

		[Column("LocationID")]
		public int? LocationID { get; private set; }

		[Column("LotSize")]
		public int? LotSize { get; private set; }

		[Column("MachineHours")]
		public double? MachineHour { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("ProductModelID")]
		public int ProductModelID { get; private set; }

		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("SetupHours")]
		public double? SetupHour { get; private set; }

		[MaxLength(1024)]
		[Column("Step")]
		public string Step { get; private set; }
	}
}

/*<Codenesium>
    <Hash>333080662df9c79a6604ae7a8a3cc6c7</Hash>
</Codenesium>*/