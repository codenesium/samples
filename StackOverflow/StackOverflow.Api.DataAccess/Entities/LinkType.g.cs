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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("Type")]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0908453f9fc3d5b1de0ee144a5384f90</Hash>
</Codenesium>*/