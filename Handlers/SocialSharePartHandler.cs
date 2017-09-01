using Moov2.Orchard.SocialShare.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Moov2.Orchard.SocialShare.Handlers
{
    public class SocialSharePartHandler : ContentHandler
    {
        public SocialSharePartHandler(IRepository<SocialSharePartRecord> socialShareRepository)
        {
            Filters.Add(StorageFilter.For(socialShareRepository));
        }
    }
}