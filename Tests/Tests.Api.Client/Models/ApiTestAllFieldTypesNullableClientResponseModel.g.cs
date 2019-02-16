using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiTestAllFieldTypesNullableClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			long? fieldBigInt,
			byte[] fieldBinary,
			bool? fieldBit,
			string fieldChar,
			DateTime? fieldDate,
			DateTime? fieldDateTime,
			DateTime? fieldDateTime2,
			DateTimeOffset? fieldDateTimeOffset,
			decimal? fieldDecimal,
			double? fieldFloat,
			byte[] fieldImage,
			decimal? fieldMoney,
			string fieldNChar,
			string fieldNText,
			decimal? fieldNumeric,
			string fieldNVarchar,
			decimal? fieldReal,
			DateTime? fieldSmallDateTime,
			short? fieldSmallInt,
			decimal? fieldSmallMoney,
			string fieldText,
			TimeSpan? fieldTime,
			byte[] fieldTimestamp,
			int? fieldTinyInt,
			Guid? fieldUniqueIdentifier,
			byte[] fieldVarBinary,
			string fieldVarchar,
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

		[JsonProperty]
		public long? FieldBigInt { get; private set; }

		[JsonProperty]
		public byte[] FieldBinary { get; private set; }

		[JsonProperty]
		public bool? FieldBit { get; private set; }

		[JsonProperty]
		public string FieldChar { get; private set; }

		[JsonProperty]
		public DateTime? FieldDate { get; private set; }

		[JsonProperty]
		public DateTime? FieldDateTime { get; private set; }

		[JsonProperty]
		public DateTime? FieldDateTime2 { get; private set; }

		[JsonProperty]
		public DateTimeOffset? FieldDateTimeOffset { get; private set; }

		[JsonProperty]
		public decimal? FieldDecimal { get; private set; }

		[JsonProperty]
		public double? FieldFloat { get; private set; }

		[JsonProperty]
		public byte[] FieldImage { get; private set; }

		[JsonProperty]
		public decimal? FieldMoney { get; private set; }

		[JsonProperty]
		public string FieldNChar { get; private set; }

		[JsonProperty]
		public string FieldNText { get; private set; }

		[JsonProperty]
		public decimal? FieldNumeric { get; private set; }

		[JsonProperty]
		public string FieldNVarchar { get; private set; }

		[JsonProperty]
		public decimal? FieldReal { get; private set; }

		[JsonProperty]
		public DateTime? FieldSmallDateTime { get; private set; }

		[JsonProperty]
		public short? FieldSmallInt { get; private set; }

		[JsonProperty]
		public decimal? FieldSmallMoney { get; private set; }

		[JsonProperty]
		public string FieldText { get; private set; }

		[JsonProperty]
		public TimeSpan? FieldTime { get; private set; }

		[JsonProperty]
		public byte[] FieldTimestamp { get; private set; }

		[JsonProperty]
		public int? FieldTinyInt { get; private set; }

		[JsonProperty]
		public Guid? FieldUniqueIdentifier { get; private set; }

		[JsonProperty]
		public byte[] FieldVarBinary { get; private set; }

		[JsonProperty]
		public string FieldVarchar { get; private set; }

		[JsonProperty]
		public string FieldXML { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c144cce382628d718d3766238ebb4efb</Hash>
</Codenesium>*/