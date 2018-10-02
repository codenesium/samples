using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("TestAllFieldTypes", Schema="dbo")]
	public partial class TestAllFieldType : AbstractEntity
	{
		public TestAllFieldType()
		{
		}

		public virtual void SetProperties(
			long fieldBigInt,
			byte[] fieldBinary,
			bool fieldBit,
			string fieldChar,
			DateTime fieldDate,
			DateTime fieldDateTime,
			DateTime fieldDateTime2,
			DateTimeOffset fieldDateTimeOffset,
			double fieldDecimal,
			double fieldFloat,
			byte[] fieldImage,
			decimal fieldMoney,
			string fieldNChar,
			string fieldNText,
			decimal fieldNumeric,
			string fieldNVarchar,
			decimal fieldReal,
			DateTime fieldSmallDateTime,
			short fieldSmallInt,
			decimal fieldSmallMoney,
			string fieldText,
			TimeSpan fieldTime,
			byte[] fieldTimestamp,
			int fieldTinyInt,
			Guid fieldUniqueIdentifier,
			byte[] fieldVarBinary,
			string fieldVarchar,
			string fieldXML,
			int id)
		{
			this.FieldBigInt = fieldBigInt;
			this.FieldBinary = fieldBinary;
			this.FieldBit = fieldBit;
			this.FieldChar = fieldChar;
			this.FieldDate = fieldDate;
			this.FieldDateTime = fieldDateTime;
			this.FieldDateTime2 = fieldDateTime2;
			this.FieldDateTimeOffset = fieldDateTimeOffset;
			this.FieldDecimal = fieldDecimal;
			this.FieldFloat = fieldFloat;
			this.FieldImage = fieldImage;
			this.FieldMoney = fieldMoney;
			this.FieldNChar = fieldNChar;
			this.FieldNText = fieldNText;
			this.FieldNumeric = fieldNumeric;
			this.FieldNVarchar = fieldNVarchar;
			this.FieldReal = fieldReal;
			this.FieldSmallDateTime = fieldSmallDateTime;
			this.FieldSmallInt = fieldSmallInt;
			this.FieldSmallMoney = fieldSmallMoney;
			this.FieldText = fieldText;
			this.FieldTime = fieldTime;
			this.FieldTimestamp = fieldTimestamp;
			this.FieldTinyInt = fieldTinyInt;
			this.FieldUniqueIdentifier = fieldUniqueIdentifier;
			this.FieldVarBinary = fieldVarBinary;
			this.FieldVarchar = fieldVarchar;
			this.FieldXML = fieldXML;
			this.Id = id;
		}

		[Column("fieldBigInt")]
		public long FieldBigInt { get; private set; }

		[MaxLength(50)]
		[Column("fieldBinary")]
		public byte[] FieldBinary { get; private set; }

		[Column("fieldBit")]
		public bool FieldBit { get; private set; }

		[MaxLength(10)]
		[Column("fieldChar")]
		public string FieldChar { get; private set; }

		[Column("fieldDate")]
		public DateTime FieldDate { get; private set; }

		[Column("fieldDateTime")]
		public DateTime FieldDateTime { get; private set; }

		[Column("fieldDateTime2")]
		public DateTime FieldDateTime2 { get; private set; }

		[Column("fieldDateTimeOffset")]
		public DateTimeOffset FieldDateTimeOffset { get; private set; }

		[Column("fieldDecimal")]
		public double FieldDecimal { get; private set; }

		[Column("fieldFloat")]
		public double FieldFloat { get; private set; }

		[Column("fieldImage")]
		public byte[] FieldImage { get; private set; }

		[Column("fieldMoney")]
		public decimal FieldMoney { get; private set; }

		[MaxLength(10)]
		[Column("fieldNChar")]
		public string FieldNChar { get; private set; }

		[MaxLength(1073741823)]
		[Column("fieldNText")]
		public string FieldNText { get; private set; }

		[Column("fieldNumeric")]
		public decimal FieldNumeric { get; private set; }

		[MaxLength(50)]
		[Column("fieldNVarchar")]
		public string FieldNVarchar { get; private set; }

		[Column("fieldReal")]
		public decimal FieldReal { get; private set; }

		[Column("fieldSmallDateTime")]
		public DateTime FieldSmallDateTime { get; private set; }

		[Column("fieldSmallInt")]
		public short FieldSmallInt { get; private set; }

		[Column("fieldSmallMoney")]
		public decimal FieldSmallMoney { get; private set; }

		[MaxLength(2147483647)]
		[Column("fieldText")]
		public string FieldText { get; private set; }

		[Column("fieldTime")]
		public TimeSpan FieldTime { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("fieldTimestamp")]
		public byte[] FieldTimestamp { get; private set; }

		[Column("fieldTinyInt")]
		public int FieldTinyInt { get; private set; }

		[Column("fieldUniqueIdentifier")]
		public Guid FieldUniqueIdentifier { get; private set; }

		[MaxLength(50)]
		[Column("fieldVarBinary")]
		public byte[] FieldVarBinary { get; private set; }

		[MaxLength(50)]
		[Column("fieldVarchar")]
		public string FieldVarchar { get; private set; }

		[Column("fieldXML")]
		public string FieldXML { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>436ca8b0d85c18fcc2a174ac67501748</Hash>
</Codenesium>*/