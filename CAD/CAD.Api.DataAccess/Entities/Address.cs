using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("Address", Schema="dbo")]
	public partial class Address : AbstractEntity
	{
		public Address()
		{
		}

		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			string city,
			string state,
			string zip)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.State = state;
			this.Zip = zip;
		}

		[MaxLength(128)]
		[Column("address1")]
		public virtual string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public virtual string Address2 { get; private set; }

		[MaxLength(128)]
		[Column("city")]
		public virtual string City { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(2)]
		[Column("state")]
		public virtual string State { get; private set; }

		[MaxLength(12)]
		[Column("zip")]
		public virtual string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8f9647f0abfa0612c64e812b62870a2f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/