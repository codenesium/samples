using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiWorkOrderResponseModel: AbstractApiResponseModel
	{
		public ApiWorkOrderResponseModel() : base()
		{}

		public void SetProperties(
			DateTime dueDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int orderQty,
			int productID,
			short scrappedQty,
			Nullable<short> scrapReasonID,
			DateTime startDate,
			int stockedQty,
			int workOrderID)
		{
			this.DueDate = dueDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderQty = orderQty.ToInt();
			this.ProductID = productID.ToInt();
			this.ScrappedQty = scrappedQty;
			this.ScrapReasonID = scrapReasonID;
			this.StartDate = startDate.ToDateTime();
			this.StockedQty = stockedQty.ToInt();
			this.WorkOrderID = workOrderID.ToInt();
		}

		public DateTime DueDate { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int OrderQty { get; set; }
		public int ProductID { get; set; }
		public short ScrappedQty { get; set; }
		public Nullable<short> ScrapReasonID { get; set; }
		public DateTime StartDate { get; set; }
		public int StockedQty { get; set; }
		public int WorkOrderID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue { get; set; } = true;

		public bool ShouldSerializeDueDate()
		{
			return this.ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue { get; set; } = true;

		public bool ShouldSerializeEndDate()
		{
			return this.ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderQtyValue { get; set; } = true;

		public bool ShouldSerializeOrderQty()
		{
			return this.ShouldSerializeOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScrappedQtyValue { get; set; } = true;

		public bool ShouldSerializeScrappedQty()
		{
			return this.ShouldSerializeScrappedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScrapReasonIDValue { get; set; } = true;

		public bool ShouldSerializeScrapReasonID()
		{
			return this.ShouldSerializeScrapReasonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStockedQtyValue { get; set; } = true;

		public bool ShouldSerializeStockedQty()
		{
			return this.ShouldSerializeStockedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWorkOrderIDValue { get; set; } = true;

		public bool ShouldSerializeWorkOrderID()
		{
			return this.ShouldSerializeWorkOrderIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDueDateValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOrderQtyValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeScrappedQtyValue = false;
			this.ShouldSerializeScrapReasonIDValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeStockedQtyValue = false;
			this.ShouldSerializeWorkOrderIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>75c3aa5b30f4103e9c4112270ed1c313</Hash>
</Codenesium>*/