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

		[Column("id2")]
		public int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2aab28f55cb565997d3dcc69cb4c7fcc</Hash>
</Codenesium>*/