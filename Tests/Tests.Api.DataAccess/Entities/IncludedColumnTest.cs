using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("IncludedColumnTest", Schema="dbo")]
	public partial class IncludedColumnTest : AbstractEntity
	{
		public IncludedColumnTest()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			string name2)
		{
			this.Id = id;
			this.Name = name;
			this.Name2 = name2;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[MaxLength(50)]
		[Column("name2")]
		public virtual string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cadb68d178ea709447268ad45bbae769</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/