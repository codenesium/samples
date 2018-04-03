using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ShoppingCartItemModel
	{
		public ShoppingCartItemModel()
		{}
		public ShoppingCartItemModel(string shoppingCartID,
		                             int quantity,
		                             int productID,
		                             DateTime dateCreated,
		                             DateTime modifiedDate)
		{
			this.ShoppingCartID = shoppingCartID;
			this.Quantity = quantity.ToInt();
			this.ProductID = productID.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _shoppingCartID;
		[Required]
		public string ShoppingCartID
		{
			get
			{
				return _shoppingCartID;
			}
			set
			{
				this._shoppingCartID = value;
			}
		}

		private int _quantity;
		[Required]
		public int Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				this._quantity = value;
			}
		}

		private int _productID;
		[Required]
		public int ProductID
		{
			get
			{
				return _productID;
			}
			set
			{
				this._productID = value;
			}
		}

		private DateTime _dateCreated;
		[Required]
		public DateTime DateCreated
		{
			get
			{
				return _dateCreated;
			}
			set
			{
				this._dateCreated = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>7c082941b7a93a05d6db4e27225016d5</Hash>
</Codenesium>*/