using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("VoteTypes", Schema="dbo")]
	public partial class VoteType : AbstractEntity
	{
		public VoteType()
		{
		}

		public virtual void SetProperties(
			int id,
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>966a1a1151db1796b92acf4304b700d7</Hash>
</Codenesium>*/