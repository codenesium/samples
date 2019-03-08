using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("LinkTypes", Schema="dbo")]
	public partial class LinkTypes : AbstractEntity
	{
		public LinkTypes()
		{
		}

		public virtual void SetProperties(
			int id,
			string rwType)
		{
			this.Id = id;
			this.RwType = rwType;
		}

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("Type")]
		public virtual string RwType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>38a2311c250cb3253d45ded114469385</Hash>
</Codenesium>*/