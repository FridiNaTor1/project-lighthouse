using System.Linq;
using System.Threading.Tasks;
using LBPUnion.ProjectLighthouse.Serialization;
using LBPUnion.ProjectLighthouse.Types;
using LBPUnion.ProjectLighthouse.Types.Levels;
using Microsoft.EntityFrameworkCore;

namespace LBPUnion.ProjectLighthouse.Helpers;

public static class SlotTypeHelper
{

    public static SlotType ParseSlotType(string str)
    {
        return str switch
        {
            "user" => SlotType.User,
            "developer" => SlotType.Developer,
            "pod" => SlotType.Pod,
            _ => SlotType.Unknown,
        };
    }

    public static bool IsValidStoryLevel(int id) => storyModeIds.Contains(id);

    public static string SlotTypeToString(SlotType type)
    {
        return type switch
        {
            SlotType.User => "user",
            SlotType.Developer => "developer",
            SlotType.Moon => "user",
            SlotType.Unknown => "unknown",
            SlotType.Unknown2 => "unknown",
            SlotType.Pod => "pod",
            SlotType.DLC => "developer",
            _ => "unknown",
        };
    }

    public static async Task<string> SerializeDeveloperSlot(Database db, int id)
    {
        int comments = await db.Comments.CountAsync(c => c.Type == CommentType.Level && c.TargetId == id && c.SlotType == SlotType.Developer);

        int photos = await db.Photos.CountAsync(p => p.SlotId == id && p.SlotType == SlotType.Developer);

        string slotData = LbpSerializer.StringElement("id", id) +
                          LbpSerializer.StringElement("playerCount", 0) +
                          LbpSerializer.StringElement("commentCount", comments) +
                          LbpSerializer.StringElement("photoCount", photos);

        return LbpSerializer.TaggedStringElement("slot", slotData, "type", "developer");
    }

    // this may not actually be feasible
    private static int[] storyModeIds =
    {
        -1,
    };
}