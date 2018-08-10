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

		Task<List<EventRelatedDocument>> ByEventId(string eventId);

		Task<List<EventRelatedDocument>> ByEventIdRelatedDocumentId(string eventId, string relatedDocumentId);

		Task<Event> GetEvent(string eventId);
	}
}

/*<Codenesium>
    <Hash>53ee937aaa0782d1062d4ed943af6e14</Hash>
</Codenesium>*/