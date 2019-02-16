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
    <Hash>1512249a12d31b50bf72eaf42c609b60</Hash>
</Codenesium>*/