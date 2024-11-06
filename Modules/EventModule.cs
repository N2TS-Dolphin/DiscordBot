using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class EventModule
    {
        private readonly DiscordClient _client;
        private readonly ulong _channelId;

        public EventModule(DiscordClient client, ulong channelId)
        {
            _client = client;
            _channelId = channelId;

            _client.GuildMemberAdded += OnGuildMemberAdded;
            _client.GuildMemberRemoved += OnGuildMemberRemoved;
        }

        private async Task OnGuildMemberAdded(DiscordClient sender, GuildMemberAddEventArgs e)
        {
            var welcomeChannel = await _client.GetChannelAsync(_channelId);
            try
            {
                if (welcomeChannel != null)
                {
                    await welcomeChannel.SendMessageAsync($"Chào mừng {e.Member.Mention} đến với server {e.Guild.Name}!");
                }
                else
                {
                    await e.Member.SendMessageAsync($"{e.Guild.Name} chào bạn!");
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task OnGuildMemberRemoved(DiscordClient sender, GuildMemberRemoveEventArgs e)
        {
            var farewellChannel = await _client.GetChannelAsync(_channelId);
            try
            {
                if (farewellChannel != null)
                {
                    await farewellChannel.SendMessageAsync($"{e.Member.Username} đã rời khỏi server {e.Guild.Name}. Chúng tôi sẽ nhớ bạn!");
                    await e.Member.SendMessageAsync($"{e.Guild.Name} tạm biệt, chúng tôi sẽ nhớ bạn!");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
