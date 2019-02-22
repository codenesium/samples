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
			int id,
			long fieldBigInt,
			byte[] fieldBinary,
			bool fieldBit,
			string fieldChar,
			DateTime fieldDate,
			DateTime fieldDateTime,
			DateTime fieldDateTime2,
			DateTimeOffset fieldDateTimeOffset,
			decimal fieldDecimal,
			double fieldFloat,
			double fieldGeography,
			double fieldGeometry,
			Guid fieldHierarchyId,
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
			string fieldVariant,
			string fieldXML)
		{
			this.Id = id;
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
			this.FieldGeography = fieldGeography;
			this.FieldGeometry = fieldGeometry;
			this.FieldHierarchyId = fieldHierarchyId;
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
			this.FieldVariant = fieldVariant;
			this.FieldXML = fieldXML;
		}

		[Column("fieldBigInt")]
		public virtual long FieldBigInt { get; private set; }

		[MaxLength(50)]
		[Column("fieldBinary")]
		public virtual byte[] FieldBinary { get; private set; }

		[Column("fieldBit")]
		public virtual bool FieldBit { get; private set; }

		[MaxLength(10)]
		[Column("fieldChar")]
		public virtual string FieldChar { get; private set; }

		[Column("fieldDate")]
		public virtual DateTime FieldDate { get; private set; }

		[Column("fieldDateTime")]
		public virtual DateTime FieldDateTime { get; private set; }

		[Column("fieldDateTime2")]
		public virtual DateTime FieldDateTime2 { get; private set; }

		[Column("fieldDateTimeOffset")]
		public virtual DateTimeOffset FieldDateTimeOffset { get; private set; }

		[Column("fieldDecimal")]
		public virtual decimal FieldDecimal { get; private set; }

		[Column("fieldFloat")]
		public virtual double FieldFloat { get; private set; }

		[Column("fieldGeography")]
		public virtual double FieldGeography { get; private set; }

		[Column("fieldGeometry")]
		public virtual double FieldGeometry { get; private set; }

		[Column("fieldHierarchyId")]
		public virtual Guid FieldHierarchyId { get; private set; }

		[Column("fieldImage")]
		public virtual byte[] FieldImage { get; private set; }

		[Column("fieldMoney")]
		public virtual decimal FieldMoney { get; private set; }

		[MaxLength(10)]
		[Column("fieldNChar")]
		public virtual string FieldNChar { get; private set; }

		[MaxLength(1073741823)]
		[Column("fieldNText")]
		public virtual string FieldNText { get; private set; }

		[Column("fieldNumeric")]
		public virtual decimal FieldNumeric { get; private set; }

		[MaxLength(50)]
		[Column("fieldNVarchar")]
		public virtual string FieldNVarchar { get; private set; }

		[Column("fieldReal")]
		public virtual decimal FieldReal { get; private set; }

		[Column("fieldSmallDateTime")]
		public virtual DateTime FieldSmallDateTime { get; private set; }

		[Column("fieldSmallInt")]
		public virtual short FieldSmallInt { get; private set; }

		[Column("fieldSmallMoney")]
		public virtual decimal FieldSmallMoney { get; private set; }

		[MaxLength(2147483647)]
		[Column("fieldText")]
		public virtual string FieldText { get; private set; }

		[Column("fieldTime")]
		public virtual TimeSpan FieldTime { get; private set; }

		[Column("fieldTimestamp")]
		public virtual byte[] FieldTimestamp { get; private set; }

		[Column("fieldTinyInt")]
		public virtual int FieldTinyInt { get; private set; }

		[Column("fieldUniqueIdentifier")]
		public virtual Guid FieldUniqueIdentifier { get; private set; }

		[MaxLength(50)]
		[Column("fieldVarBinary")]
		public virtual byte[] FieldVarBinary { get; private set; }

		[MaxLength(50)]
		[Column("fieldVarchar")]
		public virtual string FieldVarchar { get; private set; }

		[Column("fieldVariant")]
		public virtual string FieldVariant { get; private set; }

		[Column("fieldXML")]
		public virtual string FieldXML { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a15f8772771621c512570f4036cca4e9</Hash>
</Codenesium>*/