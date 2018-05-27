using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderSalesReasonResponseModel: AbstractApiResponseModel
	{
		public ApiSalesOrderHeaderSalesReasonResponseModel() : base()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			int salesOrderID,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.SalesOrderID = new ReferenceEntity<int>(salesOrderID,
			                                             nameof(ApiResponse.SalesOrderHeaders));
			this.SalesReasonID = new ReferenceEntity<int>(salesReasonID,
			                                              nameof(ApiResponse.SalesReasons));
		}

		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<int> SalesOrderID { get; set; }
		public ReferenceEntity<int> SalesReasonID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

		public bool ShouldSerializeSalesOrderID()
		{
			return this.ShouldSerializeSalesOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesReasonID()
		{
			return this.ShouldSerializeSalesReasonIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeSalesOrderIDValue = false;
			this.ShouldSerializeSalesReasonIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e82b82ba372118d9b021cbe30ddecdcd</Hash>
</Codenesium>*/