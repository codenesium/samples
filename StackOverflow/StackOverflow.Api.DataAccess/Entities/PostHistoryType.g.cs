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
			string rwtype)
		{
			this.Id = id;
			this.Type = rwtype;
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
    <Hash>034d12330e508d0a2d1b499ffcd1a022</Hash>
</Codenesium>*/