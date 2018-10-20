using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("TimestampCheck", Schema="dbo")]
	public partial class TimestampCheck : AbstractEntity
	{
		public TimestampCheck()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			byte[] timestamp)
		{
			this.Id = id;
			this.Name = name;
			this.Timestamp = timestamp;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public string Name { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("timestamp")]
		public byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>34bea66449d53d9b4850d23782c8dd8a</Hash>
</Codenesium>*/