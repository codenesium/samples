using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketingCRMNS.Api.Contracts
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
			from.SaleTickets.ForEach(x => this.AddSaleTicket(x));
			from.Tickets.ForEach(x => this.AddTicket(x));
			from.TicketStatus.ForEach(x => this.AddTicketStatu(x));
			from.Transactions.ForEach(x => this.AddTransaction(x));
			from.TransactionStatus.ForEach(x => this.AddTransactionStatu(x));
			from.Venues.ForEach(x => this.AddVenue(x));
		}

		public List<ApiAdminResponseModel> Admins { get; private set; } = new List<ApiAdminResponseModel>();

		public List<ApiCityResponseModel> Cities { get; private set; } = new List<ApiCityResponseModel>();

		public List<ApiCountryResponseModel> Countries { get; private set; } = new List<ApiCountryResponseModel>();

		public List<ApiCustomerResponseModel> Customers { get; private set; } = new List<ApiCustomerResponseModel>();

		public List<ApiEventResponseModel> Events { get; private set; } = new List<ApiEventResponseModel>();

		public List<ApiProvinceResponseModel> Provinces { get; private set; } = new List<ApiProvinceResponseModel>();

		public List<ApiSaleResponseModel> Sales { get; private set; } = new List<ApiSaleResponseModel>();

		public List<ApiSaleTicketResponseModel> SaleTickets { get; private set; } = new List<ApiSaleTicketResponseModel>();

		public List<ApiTicketResponseModel> Tickets { get; private set; } = new List<ApiTicketResponseModel>();

		public List<ApiTicketStatuResponseModel> TicketStatus { get; private set; } = new List<ApiTicketStatuResponseModel>();

		public List<ApiTransactionResponseModel> Transactions { get; private set; } = new List<ApiTransactionResponseModel>();

		public List<ApiTransactionStatuResponseModel> TransactionStatus { get; private set; } = new List<ApiTransactionStatuResponseModel>();

		public List<ApiVenueResponseModel> Venues { get; private set; } = new List<ApiVenueResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeAdminsValue { get; private set; } = true;

		public bool ShouldSerializeAdmins()
		{
			return this.ShouldSerializeAdminsValue;
		}

		public void AddAdmin(ApiAdminResponseModel item)
		{
			if (!this.Admins.Any(x => x.Id == item.Id))
			{
				this.Admins.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCitiesValue { get; private set; } = true;

		public bool ShouldSerializeCities()
		{
			return this.ShouldSerializeCitiesValue;
		}

		public void AddCity(ApiCityResponseModel item)
		{
			if (!this.Cities.Any(x => x.Id == item.Id))
			{
				this.Cities.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCountriesValue { get; private set; } = true;

		public bool ShouldSerializeCountries()
		{
			return this.ShouldSerializeCountriesValue;
		}

		public void AddCountry(ApiCountryResponseModel item)
		{
			if (!this.Countries.Any(x => x.Id == item.Id))
			{
				this.Countries.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeCustomersValue { get; private set; } = true;

		public bool ShouldSerializeCustomers()
		{
			return this.ShouldSerializeCustomersValue;
		}

		public void AddCustomer(ApiCustomerResponseModel item)
		{
			if (!this.Customers.Any(x => x.Id == item.Id))
			{
				this.Customers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEventsValue { get; private set; } = true;

		public bool ShouldSerializeEvents()
		{
			return this.ShouldSerializeEventsValue;
		}

		public void AddEvent(ApiEventResponseModel item)
		{
			if (!this.Events.Any(x => x.Id == item.Id))
			{
				this.Events.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeProvincesValue { get; private set; } = true;

		public bool ShouldSerializeProvinces()
		{
			return this.ShouldSerializeProvincesValue;
		}

		public void AddProvince(ApiProvinceResponseModel item)
		{
			if (!this.Provinces.Any(x => x.Id == item.Id))
			{
				this.Provinces.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesValue { get; private set; } = true;

		public bool ShouldSerializeSales()
		{
			return this.ShouldSerializeSalesValue;
		}

		public void AddSale(ApiSaleResponseModel item)
		{
			if (!this.Sales.Any(x => x.Id == item.Id))
			{
				this.Sales.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSaleTicketsValue { get; private set; } = true;

		public bool ShouldSerializeSaleTickets()
		{
			return this.ShouldSerializeSaleTicketsValue;
		}

		public void AddSaleTicket(ApiSaleTicketResponseModel item)
		{
			if (!this.SaleTickets.Any(x => x.Id == item.Id))
			{
				this.SaleTickets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTicketsValue { get; private set; } = true;

		public bool ShouldSerializeTickets()
		{
			return this.ShouldSerializeTicketsValue;
		}

		public void AddTicket(ApiTicketResponseModel item)
		{
			if (!this.Tickets.Any(x => x.Id == item.Id))
			{
				this.Tickets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTicketStatusValue { get; private set; } = true;

		public bool ShouldSerializeTicketStatus()
		{
			return this.ShouldSerializeTicketStatusValue;
		}

		public void AddTicketStatu(ApiTicketStatuResponseModel item)
		{
			if (!this.TicketStatus.Any(x => x.Id == item.Id))
			{
				this.TicketStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionsValue { get; private set; } = true;

		public bool ShouldSerializeTransactions()
		{
			return this.ShouldSerializeTransactionsValue;
		}

		public void AddTransaction(ApiTransactionResponseModel item)
		{
			if (!this.Transactions.Any(x => x.Id == item.Id))
			{
				this.Transactions.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTransactionStatusValue { get; private set; } = true;

		public bool ShouldSerializeTransactionStatus()
		{
			return this.ShouldSerializeTransactionStatusValue;
		}

		public void AddTransactionStatu(ApiTransactionStatuResponseModel item)
		{
			if (!this.TransactionStatus.Any(x => x.Id == item.Id))
			{
				this.TransactionStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVenuesValue { get; private set; } = true;

		public bool ShouldSerializeVenues()
		{
			return this.ShouldSerializeVenuesValue;
		}

		public void AddVenue(ApiVenueResponseModel item)
		{
			if (!this.Venues.Any(x => x.Id == item.Id))
			{
				this.Venues.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Admins.Count == 0)
			{
				this.ShouldSerializeAdminsValue = false;
			}

			if (this.Cities.Count == 0)
			{
				this.ShouldSerializeCitiesValue = false;
			}

			if (this.Countries.Count == 0)
			{
				this.ShouldSerializeCountriesValue = false;
			}

			if (this.Customers.Count == 0)
			{
				this.ShouldSerializeCustomersValue = false;
			}

			if (this.Events.Count == 0)
			{
				this.ShouldSerializeEventsValue = false;
			}

			if (this.Provinces.Count == 0)
			{
				this.ShouldSerializeProvincesValue = false;
			}

			if (this.Sales.Count == 0)
			{
				this.ShouldSerializeSalesValue = false;
			}

			if (this.SaleTickets.Count == 0)
			{
				this.ShouldSerializeSaleTicketsValue = false;
			}

			if (this.Tickets.Count == 0)
			{
				this.ShouldSerializeTicketsValue = false;
			}

			if (this.TicketStatus.Count == 0)
			{
				this.ShouldSerializeTicketStatusValue = false;
			}

			if (this.Transactions.Count == 0)
			{
				this.ShouldSerializeTransactionsValue = false;
			}

			if (this.TransactionStatus.Count == 0)
			{
				this.ShouldSerializeTransactionStatusValue = false;
			}

			if (this.Venues.Count == 0)
			{
				this.ShouldSerializeVenuesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9b76f70bad90b6c4f7cbddf64ddca0cc</Hash>
</Codenesium>*/