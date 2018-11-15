using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("UnitMeasure", Schema="Production")]
	public partial class UnitMeasure : AbstractEntity
	{
		public UnitMeasure()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			string unitMeasureCode)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[MaxLength(3)]
		[Column("UnitMeasureCode")]
		public virtual string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>99edb217c170fd944d9c07097b726605</Hash>
</Codenesium>*/