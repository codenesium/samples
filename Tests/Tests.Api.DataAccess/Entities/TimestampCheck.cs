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
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("timestamp")]
		public virtual byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>707ac72a83714e5dba5f67f8cfffa5eb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/