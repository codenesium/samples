using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Shift", Schema="HumanResources")]
	public partial class Shift : AbstractEntity
	{
		public Shift()
		{
		}

		public virtual void SetProperties(
			TimeSpan endTime,
			DateTime modifiedDate,
			string name,
			int shiftID,
			TimeSpan startTime)
		{
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ShiftID = shiftID;
			this.StartTime = startTime;
		}

		[Column("EndTime")]
		public virtual TimeSpan EndTime { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("ShiftID")]
		public virtual int ShiftID { get; private set; }

		[Column("StartTime")]
		public virtual TimeSpan StartTime { get; private set; }
	}
}

/*<Codenesium>
    <Hash>abb3a57e5b1d40511a2a114d18a2aa54</Hash>
</Codenesium>*/