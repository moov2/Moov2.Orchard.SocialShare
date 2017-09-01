using Orchard.ContentManagement;

namespace Moov2.Orchard.SocialShare.Models
{
    public class SocialSharePart : ContentPart<SocialSharePartRecord>
    {
        public bool DisplayTwitter
        {
            get { return Retrieve(x => x.DisplayTwitter); }
            set { Store(x => x.DisplayTwitter, value); }
        }

        public string TwitterText
        {
            get { return Retrieve(x => x.TwitterText); }
            set { Store(x => x.TwitterText, value); }
        }
    }
}