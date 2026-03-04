namespace LuneLib;

public partial class LuneLib : Mod
{
    public enum MessageType : byte
    {
        SetIrisIndex,
        SetMushyIndex,
        SetNotGoldArcIndex
    }

    public override void HandlePacket(BinaryReader reader, int whoAmI)
    {
        MessageType msg = (MessageType)reader.ReadByte();

        switch (msg)
        {
            case MessageType.SetIrisIndex:
                {
                    byte irisSlot = reader.ReadByte();

                    PlayerSync.IrisWhoAmI = irisSlot;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket pkt = GetPacket();
                        pkt.Write((byte)MessageType.SetIrisIndex);
                        pkt.Write(irisSlot);
                        pkt.Send(toClient: -1, ignoreClient: whoAmI);
                    }
                    break;
                }
            case MessageType.SetMushyIndex:
                {
                    byte mushySlot = reader.ReadByte();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket pkt = GetPacket();
                        pkt.Write((byte)MessageType.SetMushyIndex);
                        pkt.Write(mushySlot);
                        pkt.Send(toClient: -1, ignoreClient: whoAmI);
                    }
                    PlayerSync.MushyWhoAmI = mushySlot;
                    break;
                }
            case MessageType.SetNotGoldArcIndex:
                {
                    byte notGoldArcSlot = reader.ReadByte();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        ModPacket pkt = GetPacket();
                        pkt.Write((byte)MessageType.SetNotGoldArcIndex);
                        pkt.Write(notGoldArcSlot);
                        pkt.Send(toClient: -1, ignoreClient: whoAmI);
                    }
                    PlayerSync.NotGoldArcWhoAmI = notGoldArcSlot;
                    break;
                }
        }
    }
}