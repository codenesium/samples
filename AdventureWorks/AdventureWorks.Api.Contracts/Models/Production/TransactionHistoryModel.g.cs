using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class TransactionHistoryModel
	{
		public TransactionHistoryModel()
		{}

		public TransactionHistoryModel(
			int productID,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
			string transactionType,
			int quantity,
			decimal actualCost,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.ReferenceOrderID = referenceOrderID.ToInt();
			this.ReferenceOrderLineID = referenceOrderLineID.ToInt();
			this.TransactionDate = transactionDate.ToDateTime();
			this.TransactionType = transactionType.ToString();
			this.Quantity = quantity.ToInt();
			this.ActualCost = actualCost.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private int productID;

		[Required]
		public int ProductID
		{
			get
			{
				return this.productID;
			}

			set
			{
				this.productID = value;
			}
		}

		private int referenceOrderID;

		[Required]
		public int ReferenceOrderID
		{
			get
			{
				return this.referenceOrderID;
			}

			set
			{
				this.referenceOrderID = value;
			}
		}

		private int referenceOrderLineID;

		[Required]
		public int ReferenceOrderLineID
		{
			get
			{
				return this.referenceOrderLineID;
			}

			set
			{
				this.referenceOrderLineID = value;
			}
		}

		private DateTime transactionDate;

		[Required]
		public DateTime TransactionDate
		{
			get
			{
				return this.transactionDate;
			}

			set
			{
				this.transactionDate = value;
			}
		}

		private string transactionType;

		[Required]
		public string TransactionType
		{
			get
			{
				return this.transactionType;
			}

			set
			{
				this.transactionType = value;
			}
		}

		private int quantity;

		[Required]
		public int Quantity
		{
			get
			{
				return this.quantity;
			}

			set
			{
				this.quantity = value;
			}
		}

		private decimal actualCost;

		[Required]
		public decimal ActualCost
		{
			get
			{
				return this.actualCost;
			}

			set
			{
				this.actualCost = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2c44b14c5d74a4fb4bf2495958046299</Hash>
</Codenesium>*/