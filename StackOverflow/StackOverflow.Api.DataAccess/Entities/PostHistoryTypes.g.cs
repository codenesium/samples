using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("PostHistoryTypes", Schema="dbo")]
	public partial class PostHistoryTypes : AbstractEntity
	{
		public PostHistoryTypes()
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
    <Hash>a6b08f5de2da3bc19d3bbfff586f0aa4</Hash>
</Codenesium>*/