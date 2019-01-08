using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiTestAllFieldTypeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTestAllFieldTypeServerRequestModel()
			: base()
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
		}

		[Required]
		[JsonProperty]
		public long FieldBigInt { get; private set; } = default(long);

		[Required]
		[JsonProperty]
		public byte[] FieldBinary { get; private set; } = default(byte[]);

		[Required]
		[JsonProperty]
		public bool FieldBit { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string FieldChar { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime FieldDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public DateTime FieldDateTime { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public DateTime FieldDateTime2 { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public DateTimeOffset FieldDateTimeOffset { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public double FieldDecimal { get; private set; } = default(double);

		[Required]
		[JsonProperty]
		public double FieldFloat { get; private set; } = default(double);

		[Required]
		[JsonProperty]
		public byte[] FieldImage { get; private set; } = default(byte[]);

		[Required]
		[JsonProperty]
		public decimal FieldMoney { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string FieldNChar { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FieldNText { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public decimal FieldNumeric { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string FieldNVarchar { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public decimal FieldReal { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime FieldSmallDateTime { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public short FieldSmallInt { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public decimal FieldSmallMoney { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string FieldText { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public TimeSpan FieldTime { get; private set; } = default(TimeSpan);

		[Required]
		[JsonProperty]
		public byte[] FieldTimestamp { get; private set; } = default(byte[]);

		[Required]
		[JsonProperty]
		public int FieldTinyInt { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public Guid FieldUniqueIdentifier { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public byte[] FieldVarBinary { get; private set; } = default(byte[]);

		[Required]
		[JsonProperty]
		public string FieldVarchar { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FieldXML { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>699cf1d4842393780aa18551ed630b06</Hash>
</Codenesium>*/