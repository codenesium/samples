using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("LinkTypes", Schema="dbo")]
	public partial class LinkType : AbstractEntity
	{
		public LinkType()
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
    <Hash>40da854eacf956ef0ce71046c9cb95d0</Hash>
</Codenesium>*/