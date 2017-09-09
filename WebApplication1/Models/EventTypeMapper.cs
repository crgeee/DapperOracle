using DapperExtensions.Mapper;

namespace WebApplication1.Models
{
    public sealed class EventTypeMapper : ClassMapper<EventType>
    {
        public EventTypeMapper()
        {
            Schema("pccb");
            Table("EVENT_TYPE");
            Map(x => x.EventTypeId).Column("EVENT_TYPE_ID").Key(KeyType.TriggerIdentity);
            Map(x => x.Name).Column("NAME");
            Map(x => x.CreatedBy).Column("CREATED_BY");
            Map(x => x.CreatedDate).Column("CREATED_DATE");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.IsDeleted).Column("IS_DELETED");
            Map(x => x.TimelineUnits).Column("TIMELINE_UNITS");
            Map(x => x.ModifiedBy).Column("MODIFIED_BY");
            Map(x => x.ModifiedDate).Column("MODIFIED_DATE");
            AutoMap();
        }
    }
}