using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOTestAllFieldType : AbstractBusinessObject
	{
		public AbstractBOTestAllFieldType()
			: base()
		{
		}

		public virtual void SetProperties(int id,
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
		                                  string fieldXML)
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

		public long FieldBigInt { get; private set; }

		public byte[] FieldBinary { get; private set; }

		public bool FieldBit { get; private set; }

		public string FieldChar { get; private set; }

		public DateTime FieldDate { get; private set; }

		public DateTime FieldDateTime { get; private set; }

		public DateTime FieldDateTime2 { get; private set; }

		public DateTimeOffset FieldDateTimeOffset { get; private set; }

		public double FieldDecimal { get; private set; }

		public double FieldFloat { get; private set; }

		public byte[] FieldImage { get; private set; }

		public decimal FieldMoney { get; private set; }

		public string FieldNChar { get; private set; }

		public string FieldNText { get; private set; }

		public decimal FieldNumeric { get; private set; }

		public string FieldNVarchar { get; private set; }

		public decimal FieldReal { get; private set; }

		public DateTime FieldSmallDateTime { get; private set; }

		public short FieldSmallInt { get; private set; }

		public decimal FieldSmallMoney { get; private set; }

		public string FieldText { get; private set; }

		public TimeSpan FieldTime { get; private set; }

		public byte[] FieldTimestamp { get; private set; }

		public int FieldTinyInt { get; private set; }

		public Guid FieldUniqueIdentifier { get; private set; }

		public byte[] FieldVarBinary { get; private set; }

		public string FieldVarchar { get; private set; }

		public string FieldXML { get; private set; }

		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e29ceba696756ad8d3e0052885ec31ed</Hash>
</Codenesium>*/