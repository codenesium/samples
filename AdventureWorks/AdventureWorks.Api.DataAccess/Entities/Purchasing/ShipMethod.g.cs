using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShipMethod", Schema="Purchasing")]
	public partial class ShipMethod : AbstractEntity
	{
		public ShipMethod()
		{
		}

		public virtual void SetProperties(
			int shipMethodID,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			decimal shipRate)
		{
			this.ShipMethodID = shipMethodID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ShipBase = shipBase;
			this.ShipRate = shipRate;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("ShipBase")]
		public virtual decimal ShipBase { get; private set; }

		[Key]
		[Column("ShipMethodID")]
		public virtual int ShipMethodID { get; private set; }

		[Column("ShipRate")]
		public virtual decimal ShipRate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3dfe2faee39ab9113e20a3ffaa2c9868</Hash>
</Codenesium>*/