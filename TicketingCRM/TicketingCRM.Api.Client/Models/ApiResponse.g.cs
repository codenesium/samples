using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Admins.ForEach(x => this.AddAdmin(x));
			from.Cities.ForEach(x => this.AddCity(x));
			from.Countries.ForEach(x => this.AddCountry(x));
			from.Customers.ForEach(x => this.AddCustomer(x));
			from.Events.ForEach(x => this.AddEvent(x));
			from.Provinces.ForEach(x => this.AddProvince(x));
			from.Sales.ForEach(x => this.AddSale(x));
			from.Tickets.ForEach(x => this.AddTicket(x));
			from.TicketStatus.ForEach(x => this.AddTicketStatu(x));
			from.Transactions.ForEach(x => this.AddTransaction(x));
			from.TransactionStatus.ForEach(x => this.AddTransactionStatu(x));
			from.Venues.ForEach(x => this.AddVenue(x));
		}

		public List<ApiAdminClientResponseModel> Admins { get; private set; } = new List<ApiAdminClientResponseModel>();

		public List<ApiCityClientResponseModel> Cities { get; private set; } = new List<ApiCityClientResponseModel>();

		public List<ApiCountryClientResponseModel> Countries { get; private set; } = new List<ApiCountryClientResponseModel>();

		public List<ApiCustomerClientResponseModel> Customers { get; private set; } = new List<ApiCustomerClientResponseModel>();

		public List<ApiEventClientResponseModel> Events { get; private set; } = new List<ApiEventClientResponseModel>();

		public List<ApiProvinceClientResponseModel> Provinces { get; private set; } = new List<ApiProvinceClientResponseModel>();

		public List<ApiSaleClientResponseModel> Sales { get; private set; } = new List<ApiSaleClientResponseModel>();

		public List<ApiTicketClientResponseModel> Tickets { get; private set; } = new List<ApiTicketClientResponseModel>();

		public List<ApiTicketStatuClientResponseModel> TicketStatus { get; private set; } = new List<ApiTicketStatuClientResponseModel>();

		public List<ApiTransactionClientResponseModel> Transactions { get; private set; } = new List<ApiTransactionClientResponseModel>();

		public List<ApiTransactionStatuClientResponseModel> TransactionStatus { get; private set; } = new List<ApiTransactionStatuClientResponseModel>();

		public List<ApiVenueClientResponseModel> Venues { get; private set; } = new List<ApiVenueClientResponseModel>();

		public void AddAdmin(ApiAdminClientResponseModel item)
		{
			if (!this.Admins.Any(x => x.Id == item.Id))
			{
				this.Admins.Add(item);
			}
		}

		public void AddCity(ApiCityClientResponseModel item)
		{
			if (!this.Cities.Any(x => x.Id == item.Id))
			{
				this.Cities.Add(item);
			}
		}

		public void AddCountry(ApiCountryClientResponseModel item)
		{
			if (!this.Countries.Any(x => x.Id == item.Id))
			{
				this.Countries.Add(item);
			}
		}

		public void AddCustomer(ApiCustomerClientResponseModel item)
		{
			if (!this.Customers.Any(x => x.Id == item.Id))
			{
				this.Customers.Add(item);
			}
		}

		public void AddEvent(ApiEventClientResponseModel item)
		{
			if (!this.Events.Any(x => x.Id == item.Id))
			{
				this.Events.Add(item);
			}
		}

		public void AddProvince(ApiProvinceClientResponseModel item)
		{
			if (!this.Provinces.Any(x => x.Id == item.Id))
			{
				this.Provinces.Add(item);
			}
		}

		public void AddSale(ApiSaleClientResponseModel item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		public void AddTicket(ApiTicketClientResponseModel item)
		{
			if (!this.Tickets.Any(x => x.Id == item.Id))
			{
				this.Tickets.Add(item);
			}
		}

		public void AddTicketStatu(ApiTicketStatuClientResponseModel item)
		{
			if (!this.TicketStatus.Any(x => x.Id == item.Id))
			{
				this.TicketStatus.Add(item);
			}
		}

		public void AddTransaction(ApiTransactionClientResponseModel item)
		{
			if (!this.Transactions.Any(x => x.Id == item.Id))
			{
				this.Transactions.Add(item);
			}
		}

		public void AddTransactionStatu(ApiTransactionStatuClientResponseModel item)
		{
			if (!this.TransactionStatus.Any(x => x.Id == item.Id))
			{
				this.TransactionStatus.Add(item);
			}
		}

		public void AddVenue(ApiVenueClientResponseModel item)
		{
			if (!this.Venues.Any(x => x.Id == item.Id))
			{
				this.Venues.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>468776ec6f774c9ffab6b7458dec9151</Hash>
</Codenesium>*/