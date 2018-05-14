using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Airline", Schema="dbo")]
	public partial class Airline: AbstractEntityFrameworkPOCO
	{
		public Airline()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>f33b16095cae4cd5ade714e97a065c5b</Hash>
</Codenesium>*/