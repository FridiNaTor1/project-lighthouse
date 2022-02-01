using System.Threading.Tasks;
using Discord;
using Discord.Webhook;
using LBPUnion.ProjectLighthouse.Types.Settings;

namespace LBPUnion.ProjectLighthouse.Helpers;

public static class WebhookHelper
{
    private static readonly DiscordWebhookClient client = (ServerSettings.Instance.DiscordWebhookEnabled ? new DiscordWebhookClient(ServerSettings.Instance.DiscordWebhookUrl) : null);
    public static readonly Color UnionColor = new(129,203,140);

    public static Task SendWebhook(EmbedBuilder builder) => SendWebhook(builder.Build());

    public static async Task SendWebhook(Embed embed)
    {
        if (!ServerSettings.Instance.DiscordWebhookEnabled) return;

        await client.SendMessageAsync
        (
            embeds: new[]
            {
                embed,
            }
        );
    }

    public static Task SendWebhook(string title, string description)
        => SendWebhook
        (
            new EmbedBuilder
            {
                Title = title,
                Description = description,
                Color = UnionColor,
            }
        );
}