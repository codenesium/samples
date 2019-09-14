using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class HandlerPipelineStepCreatedHandler : INotificationHandler<HandlerPipelineStepCreatedNotification>
	{
		public async Task Handle(HandlerPipelineStepCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class HandlerPipelineStepUpdatedHandler : INotificationHandler<HandlerPipelineStepUpdatedNotification>
	{
		public async Task Handle(HandlerPipelineStepUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class HandlerPipelineStepDeletedHandler : INotificationHandler<HandlerPipelineStepDeletedNotification>
	{
		public async Task Handle(HandlerPipelineStepDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class HandlerPipelineStepCreatedNotification : INotification
	{
		public ApiHandlerPipelineStepServerResponseModel Record { get; private set; }

		public HandlerPipelineStepCreatedNotification(ApiHandlerPipelineStepServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class HandlerPipelineStepUpdatedNotification : INotification
	{
		public ApiHandlerPipelineStepServerResponseModel Record { get; private set; }

		public HandlerPipelineStepUpdatedNotification(ApiHandlerPipelineStepServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class HandlerPipelineStepDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public HandlerPipelineStepDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>540f56c7705cb3b60b2c47da603f45a9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/