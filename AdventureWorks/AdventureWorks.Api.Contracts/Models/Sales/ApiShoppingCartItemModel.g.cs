using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShoppingCartItemModel: AbstractModel
	{
		public ApiShoppingCartItemModel() : base()
		{}

		public ApiShoppingCartItemModel(
			DateTime dateCreated,
			DateTime modifiedDate,
			int productID,
			int quantity,
			string shoppingCartID)
		{
			this.DateCreated = dateCreated.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Quantity = quantity.ToInt();
			this.ShoppingCartID = shoppingCartID;
		}

		private DateTime dateCreated;

		[Required]
		public DateTime DateCreated
		{
			get
			{
				return this.dateCreated;
			}

			set
			{
				this.dateCreated = value;
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

		private string shoppingCartID;

		[Required]
		public string ShoppingCartID
		{
			get
			{
				return this.shoppingCartID;
			}

			set
			{
				this.shoppingCartID = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b84256307d43fb7f0389ae8525ef235c</Hash>
</Codenesium>*/