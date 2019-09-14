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
    <Hash>bacb27df9ddd6d340b4013395feaf169</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/