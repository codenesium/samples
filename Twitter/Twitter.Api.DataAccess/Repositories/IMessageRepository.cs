using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial interface IMessageRepository
	{
		Task<Message> Create(Message item);

		Task Update(Message item);

		Task Delete(int messageId);

		Task<Message> Get(int messageId);

		Task<List<Message>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Message>> BySenderUserId(int? senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<Messenger>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0);

		Task<User> UserBySenderUserId(int? senderUserId);
	}
}

/*<Codenesium>
    <Hash>cb83dcaacd87c1f988d8db0ee0c2e48a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/