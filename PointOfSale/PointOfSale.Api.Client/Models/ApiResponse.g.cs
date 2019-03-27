using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Customers.ForEach(x => this.AddCustomer(x));
			from.Products.ForEach(x => this.AddProduct(x));
			from.Sales.ForEach(x => this.AddSale(x));
		}

		public List<ApiCustomerClientResponseModel> Customers { get; private set; } = new List<ApiCustomerClientResponseModel>();

		public List<ApiProductClientResponseModel> Products { get; private set; } = new List<ApiProductClientResponseModel>();

		public List<ApiSaleClientResponseModel> Sales { get; private set; } = new List<ApiSaleClientResponseModel>();

		public void AddCustomer(ApiCustomerClientResponseModel item)
		{
			if (!this.Customers.Any(x => x.Id == item.Id))
			{
				this.Customers.Add(item);
			}
		}

		public void AddProduct(ApiProductClientResponseModel item)
		{
			if (!this.Products.Any(x => x.Id == item.Id))
			{
				this.Products.Add(item);
			}
		}

		public void AddSale(ApiSaleClientResponseModel item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>b081c90e46fec2b5de61b90ece1f991f</Hash>
</Codenesium>*/