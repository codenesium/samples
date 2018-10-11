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
		public int Id { get; private set; }

		[Key]
		[Column("id2")]
		public int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fbce2e33cbf1561e7858651b3b727f07</Hash>
</Codenesium>*/