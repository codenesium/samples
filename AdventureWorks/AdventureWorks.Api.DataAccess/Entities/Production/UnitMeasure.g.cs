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
		public DateTime ModifiedDate { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Key]
		[Column("UnitMeasureCode")]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0d7615c0a8921c551edd00a4f6695bee</Hash>
</Codenesium>*/