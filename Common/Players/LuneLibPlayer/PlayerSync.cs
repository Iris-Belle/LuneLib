namespace LuneLib.Common.Players.LuneLibPlayer;

public class PlayerSync : ModPlayer
{
    public static int IrisWhoAmI = -1;
    public static int MushyWhoAmI = -1;
    public static int NotGoldArcWhoAmI = -1;

    public override void PostUpdate()
    {
        if (Main.netMode != NetmodeID.SinglePlayer && Main.myPlayer == Player.whoAmI && Wait(60))
        {
            if (AmIIrisBySteamID())
            {
                IrisWhoAmI = Player.whoAmI;
                ModPacket pkt = Mod.GetPacket();
                pkt.Write((byte)MessageType.SetIrisIndex);
                pkt.Write((byte)IrisWhoAmI);
                pkt.Send();
            }
            else if (AmIMushyBySteamID())
            {
                MushyWhoAmI = Player.whoAmI;
                ModPacket pkt = Mod.GetPacket();
                pkt.Write((byte)MessageType.SetMushyIndex);
                pkt.Write((byte)MushyWhoAmI);
                pkt.Send();
            }
            else if (AmINotGoldArcBySteamID())
            {
                NotGoldArcWhoAmI = Player.whoAmI;
                ModPacket pkt = Mod.GetPacket();
                pkt.Write((byte)MessageType.SetNotGoldArcIndex);
                pkt.Write((byte)NotGoldArcWhoAmI);
                pkt.Send();
            }
        }
    }

    public static bool AmIIrisBySteamID()
    {
        CSteamID id = SteamUser.GetSteamID();
        return id.m_SteamID == 76561198818748376UL && debug.CheckIris;
    }

    public static bool AmIMushyBySteamID()
    {
        CSteamID id = SteamUser.GetSteamID();
        return id.m_SteamID == 76561199229515262UL && debug.CheckMushy;
    }

    public static bool AmINotGoldArcBySteamID()
    {
        CSteamID id = SteamUser.GetSteamID();
        return id.m_SteamID == 76561199519588593UL && debug.CheckNotGoldArc;
    }
}