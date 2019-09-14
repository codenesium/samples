using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStatusCreatedHandler : INotificationHandler<PipelineStatusCreatedNotification>
	{
		public async Task Handle(PipelineStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStatusUpdatedHandler : INotificationHandler<PipelineStatusUpdatedNotification>
	{
		public async Task Handle(PipelineStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStatusDeletedHandler : INotificationHandler<PipelineStatusDeletedNotification>
	{
		public async Task Handle(PipelineStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStatusCreatedNotification : INotification
	{
		public ApiPipelineStatusServerResponseModel Record { get; private set; }

		public PipelineStatusCreatedNotification(ApiPipelineStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStatusUpdatedNotification : INotification
	{
		public ApiPipelineStatusServerResponseModel Record { get; private set; }

		public PipelineStatusUpdatedNotification(ApiPipelineStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>6719f63a2479603d32400d24626a1392</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/