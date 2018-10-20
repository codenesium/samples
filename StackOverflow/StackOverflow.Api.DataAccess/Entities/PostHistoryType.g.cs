using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostHistoryTypes", Schema="dbo")]
	public partial class PostHistoryType : AbstractEntity
	{
		public PostHistoryType()
		{
		}

		public virtual void SetProperties(
			int id,
			string type)
		{
			this.Id = id;
			this.Type = type;
		}

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("Type")]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1209757e4398749298bd251c9c88231f</Hash>
</Codenesium>*/