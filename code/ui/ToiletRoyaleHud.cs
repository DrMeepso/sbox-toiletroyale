using Sandbox;
using Sandbox.UI;

namespace ToiletRoyale
{
	public partial class ToiletRoyaleHud : HudEntity<RootPanel>
	{
		public ToiletRoyaleHud()
		{
			if ( !IsClient )
				return;

			RootPanel.StyleSheet.Load( "/ui/ToiletRoyaleHud.scss" );

			NameTags NameTags = RootPanel.AddChild<NameTags>();

			NameTags.MaxTagsToShow = 8;

			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<VoiceList>();
		}
	}

}
