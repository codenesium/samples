namespace StudioResourceManagerNS.Api.DataAccess
{
    public abstract class AbstractEntity
    { 
		public int TenantId { get; set; }
 
		public bool IsDeleted { get; set; }
 
	}
}