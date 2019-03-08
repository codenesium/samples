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
    <Hash>72847033b4c6207bd59e33c20ded4877</Hash>
</Codenesium>*/