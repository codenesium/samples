using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Location", Schema="Production")]
	public partial class Location : AbstractEntity
	{
		public Location()
		{
		}

		public virtual void SetProperties(
			double availability,
			decimal costRate,
			short locationID,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability;
			this.CostRate = costRate;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Column("Availability")]
		public virtual double Availability { get; private set; }

		[Column("CostRate")]
		public virtual decimal CostRate { get; private set; }

		[Key]
		[Column("LocationID")]
		public virtual short LocationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c30a544ed804b75fe682a4c06ba44d8f</Hash>
</Codenesium>*/