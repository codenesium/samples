using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("compositePrimaryKey", Schema="dbo")]
	public partial class CompositePrimaryKey : AbstractEntity
	{
		public CompositePrimaryKey()
		{
		}

		public virtual void SetProperties(
			int id,
			int id2)
		{
			this.Id = id;
			this.Id2 = id2;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Key]
		[Column("id2")]
		public virtual int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>de77e224ba2e342862def3e388fb284c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/