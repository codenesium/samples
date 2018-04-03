using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOWorkOrder
	{
		public POCOWorkOrder()
		{}

		public POCOWorkOrder(int workOrderID,
		                     int productID,
		                     int orderQty,
		                     int stockedQty,
		                     short scrappedQty,
		                     DateTime startDate,
		                     Nullable<DateTime> endDate,
		                     DateTime dueDate,
		                     Nullable<short> scrapReasonID,
		                     DateTime modifiedDate)
		{
			this.WorkOrderID = workOrderID.ToInt();
			this.ProductID = productID.ToInt();
			this.OrderQty = orderQty.ToInt();
			this.StockedQty = stockedQty.ToInt();
			this.ScrappedQty = scrappedQty;
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ScrapReasonID = scrapReasonID;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int WorkOrderID {get; set;}
		public int ProductID {get; set;}
		public int OrderQty {get; set;}
		public int StockedQty {get; set;}
		public short ScrappedQty {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public DateTime DueDate {get; set;}
		public Nullable<short> ScrapReasonID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeWorkOrderIDValue {get; set;} = true;

		public bool ShouldSerializeWorkOrderID()
		{
			return ShouldSerializeWorkOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderQtyValue {get; set;} = true;

		public bool ShouldSerializeOrderQty()
		{
			return ShouldSerializeOrderQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStockedQtyValue {get; set;} = true;

		public bool ShouldSerializeStockedQty()
		{
			return ShouldSerializeStockedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScrappedQtyValue {get; set;} = true;

		public bool ShouldSerializeScrappedQty()
		{
			return ShouldSerializeScrappedQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue {get; set;} = true;

		public bool ShouldSerializeStartDate()
		{
			return ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue {get; set;} = true;

		public bool ShouldSerializeEndDate()
		{
			return ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDueDateValue {get; set;} = true;

		public bool ShouldSerializeDueDate()
		{
			return ShouldSerializeDueDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScrapReasonIDValue {get; set;} = true;

		public bool ShouldSerializeScrapReasonID()
		{
			return ShouldSerializeScrapReasonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeWorkOrderIDValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeOrderQtyValue = false;
			this.ShouldSerializeStockedQtyValue = false;
			this.ShouldSerializeScrappedQtyValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeDueDateValue = false;
			this.ShouldSerializeScrapReasonIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>16158ef6c0e7f623c2c81582e9930bad</Hash>
</Codenesium>*/