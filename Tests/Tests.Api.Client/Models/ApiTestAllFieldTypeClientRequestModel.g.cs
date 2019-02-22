using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiTestAllFieldTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTestAllFieldTypeClientRequestModel()
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

		[JsonProperty]
		public long FieldBigInt { get; private set; } = default(long);

		[JsonProperty]
		public byte[] FieldBinary { get; private set; } = default(byte[]);

		[JsonProperty]
		public bool FieldBit { get; private set; } = default(bool);

		[JsonProperty]
		public string FieldChar { get; private set; } = default(string);

		[JsonProperty]
		public DateTime FieldDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime FieldDateTime { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime FieldDateTime2 { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTimeOffset FieldDateTimeOffset { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public decimal FieldDecimal { get; private set; } = default(decimal);

		[JsonProperty]
		public double FieldFloat { get; private set; } = default(double);

		[JsonProperty]
		public double FieldGeography { get; private set; } = default(double);

		[JsonProperty]
		public double FieldGeometry { get; private set; } = default(double);

		[JsonProperty]
		public Guid FieldHierarchyId { get; private set; } = default(Guid);

		[JsonProperty]
		public byte[] FieldImage { get; private set; } = default(byte[]);

		[JsonProperty]
		public decimal FieldMoney { get; private set; } = default(decimal);

		[JsonProperty]
		public string FieldNChar { get; private set; } = default(string);

		[JsonProperty]
		public string FieldNText { get; private set; } = default(string);

		[JsonProperty]
		public decimal FieldNumeric { get; private set; } = default(decimal);

		[JsonProperty]
		public string FieldNVarchar { get; private set; } = default(string);

		[JsonProperty]
		public decimal FieldReal { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime FieldSmallDateTime { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public short FieldSmallInt { get; private set; } = default(short);

		[JsonProperty]
		public decimal FieldSmallMoney { get; private set; } = default(decimal);

		[JsonProperty]
		public string FieldText { get; private set; } = default(string);

		[JsonProperty]
		public TimeSpan FieldTime { get; private set; } = default(TimeSpan);

		[JsonProperty]
		public byte[] FieldTimestamp { get; private set; } = default(byte[]);

		[JsonProperty]
		public int FieldTinyInt { get; private set; } = default(int);

		[JsonProperty]
		public Guid FieldUniqueIdentifier { get; private set; } = default(Guid);

		[JsonProperty]
		public byte[] FieldVarBinary { get; private set; } = default(byte[]);

		[JsonProperty]
		public string FieldVarchar { get; private set; } = default(string);

		[JsonProperty]
		public string FieldVariant { get; private set; } = default(string);

		[JsonProperty]
		public string FieldXML { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>c96e9321015913a2e8926d6cb5099a4e</Hash>
</Codenesium>*/