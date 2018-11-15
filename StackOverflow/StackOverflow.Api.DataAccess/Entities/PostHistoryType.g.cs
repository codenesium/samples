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
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("Type")]
		public virtual string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a2a59f92ff8d526f99c45a9f0db9ac74</Hash>
</Codenesium>*/