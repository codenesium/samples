using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class NoteCreatedHandler : INotificationHandler<NoteCreatedNotification>
	{
		public async Task Handle(NoteCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class NoteUpdatedHandler : INotificationHandler<NoteUpdatedNotification>
	{
		public async Task Handle(NoteUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class NoteDeletedHandler : INotificationHandler<NoteDeletedNotification>
	{
		public async Task Handle(NoteDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class NoteCreatedNotification : INotification
	{
		public ApiNoteServerResponseModel Record { get; private set; }

		public NoteCreatedNotification(ApiNoteServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class NoteUpdatedNotification : INotification
	{
		public ApiNoteServerResponseModel Record { get; private set; }

		public NoteUpdatedNotification(ApiNoteServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class NoteDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public NoteDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>93d7682d371507e8cdc12f64d151115d</Hash>
</Codenesium>*/