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
			string unitMeasureCode,
			DateTime modifiedDate,
			string name)
		{
			this.UnitMeasureCode = unitMeasureCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
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
    <Hash>1a3ade59777a3423e90f893d6f972c86</Hash>
</Codenesium>*/