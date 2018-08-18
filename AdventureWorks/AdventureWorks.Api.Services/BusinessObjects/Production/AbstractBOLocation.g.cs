using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOLocation : AbstractBusinessObject
	{
		public AbstractBOLocation()
			: base()
		{
		}

		public virtual void SetProperties(short locationID,
		                                  double availability,
		                                  decimal costRate,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.Availability = availability;
			this.CostRate = costRate;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		public double Availability { get; private set; }

		public decimal CostRate { get; private set; }

		public short LocationID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>13f16414cc890c0fdef0a5aa30054f08</Hash>
</Codenesium>*/