using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepNoteCreatedHandler : INotificationHandler<PipelineStepNoteCreatedNotification>
	{
		public async Task Handle(PipelineStepNoteCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepNoteUpdatedHandler : INotificationHandler<PipelineStepNoteUpdatedNotification>
	{
		public async Task Handle(PipelineStepNoteUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepNoteDeletedHandler : INotificationHandler<PipelineStepNoteDeletedNotification>
	{
		public async Task Handle(PipelineStepNoteDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepNoteCreatedNotification : INotification
	{
		public ApiPipelineStepNoteServerResponseModel Record { get; private set; }

		public PipelineStepNoteCreatedNotification(ApiPipelineStepNoteServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepNoteUpdatedNotification : INotification
	{
		public ApiPipelineStepNoteServerResponseModel Record { get; private set; }

		public PipelineStepNoteUpdatedNotification(ApiPipelineStepNoteServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepNoteDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStepNoteDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>7822e9bcfb2c34fc32f51e215219ea6f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/