using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class PaymentTypeCreatedHandler : INotificationHandler<PaymentTypeCreatedNotification>
	{
		public async Task Handle(PaymentTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PaymentTypeUpdatedHandler : INotificationHandler<PaymentTypeUpdatedNotification>
	{
		public async Task Handle(PaymentTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PaymentTypeDeletedHandler : INotificationHandler<PaymentTypeDeletedNotification>
	{
		public async Task Handle(PaymentTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PaymentTypeCreatedNotification : INotification
	{
		public ApiPaymentTypeServerResponseModel Record { get; private set; }

		public PaymentTypeCreatedNotification(ApiPaymentTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PaymentTypeUpdatedNotification : INotification
	{
		public ApiPaymentTypeServerResponseModel Record { get; private set; }

		public PaymentTypeUpdatedNotification(ApiPaymentTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PaymentTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PaymentTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>f011c557c05b2228249f5d8c1b05fe91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/