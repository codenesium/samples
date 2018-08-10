using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("VoteTypes", Schema="dbo")]
	public partial class VoteTypes : AbstractEntity
	{
		public VoteTypes()
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

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8e27e20b8b6be78a1f9bf9e56cbce7bc</Hash>
</Codenesium>*/