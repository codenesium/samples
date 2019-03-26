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
		public virtual string Instruction { get; private set; }

		[Column("LaborHours")]
		public virtual double? LaborHour { get; private set; }

		[Column("LocationID")]
		public virtual int? LocationID { get; private set; }

		[Column("LotSize")]
		public virtual int? LotSize { get; private set; }

		[Column("MachineHours")]
		public virtual double? MachineHour { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SetupHours")]
		public virtual double? SetupHour { get; private set; }

		[MaxLength(1024)]
		[Column("Step")]
		public virtual string Step { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a3043f4b6e2da14cf86337ce32c2972e</Hash>
</Codenesium>*/