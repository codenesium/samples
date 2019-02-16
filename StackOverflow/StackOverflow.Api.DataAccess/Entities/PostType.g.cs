using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostTypes", Schema="dbo")]
	public partial class PostType : AbstractEntity
	{
		public PostType()
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
    <Hash>90a7e40c7a132d454c9aafb5de679134</Hash>
</Codenesium>*/