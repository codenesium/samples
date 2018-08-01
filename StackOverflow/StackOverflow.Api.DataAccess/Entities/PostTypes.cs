using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostTypes", Schema="dbo")]
	public partial class PostTypes : AbstractEntity
	{
		public PostTypes()
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

		[Column("Type")]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>007b0cfd8b460aaef840abf66d718f86</Hash>
</Codenesium>*/