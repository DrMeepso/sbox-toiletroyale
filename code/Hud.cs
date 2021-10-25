using Sandbox.UI;

namespace ToiletRoyale
{
	public partial class HudEntity : Sandbox.HudEntity<RootPanel>
	{
		public HudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "ui/Hud.html" );
			}
		}
	}

}
