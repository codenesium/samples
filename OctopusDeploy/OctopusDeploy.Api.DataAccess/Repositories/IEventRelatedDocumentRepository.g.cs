using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IEventRelatedDocumentRepository
	{
		Task<EventRelatedDocument> Create(EventRelatedDocument item);

		Task Update(EventRelatedDocument item);

		Task Delete(int id);

		Task<EventRelatedDocument> Get(int id);

		Task<List<EventRelatedDocument>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EventRelatedDocument>> ByEventId(string eventId, int limit = int.MaxValue, int offset = 0);

		Task<List<EventRelatedDocument>> ByEventIdRelatedDocumentId(string eventId, string relatedDocumentId, int limit = int.MaxValue, int offset = 0);

		Task<Event> GetEvent(string eventId);
	}
}

/*<Codenesium>
    <Hash>e643ad408f8554f3cfd3837a96c1fbe4</Hash>
</Codenesium>*/