using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using System.Data;

namespace Bot.Modules
{
    public class BasicFunctionality : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong!");
        }

        [Command("echo")]
        public async Task Echo([Remainder] string text)
        {
            await ReplyAsync(text);
        }

        [Command("math")]
        public async Task Math([Remainder] string math)
        {
            var dt = new DataTable();
            var result = dt.Compute(math, null);

            await ReplyAsync(result.ToString());
        }

        [Command("info")]
        public async Task Info(SocketGuildUser user = null)
        {
            if (user == null)
            {
                var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                .WithDescription("Information about you!")
                .WithColor(new Color(255, 0, 170))
                .AddField("User ID", Context.User.Id, true)
                .AddField("Discriminator", Context.User.Discriminator, true)
                .AddField("Created on", Context.User.CreatedAt.LocalDateTime.ToString())
                .AddField("Joined at", (Context.User as SocketGuildUser).JoinedAt.Value.LocalDateTime.ToString(), true)
                .AddField("Personality type", Context.User.Id != 150567114871144448 ? "Cringe" : "Based", true);

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else
            {
                var builder = new EmbedBuilder()
                .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                .WithDescription($"Information about {user.Username}")
                .WithColor(new Color(255, 0, 170))
                .AddField("User ID", user.Id, true)
                .AddField("Discriminator", user.Discriminator, true)
                .AddField("Created on", user.CreatedAt.LocalDateTime.ToString())
                .AddField("Joined at", user.JoinedAt.Value.LocalDateTime.ToString(), true)
                .AddField("Personality type", user.Id != 150567114871144448 ? "Cringe" : "Based", true);

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
        }

        [Command("server")]
        public async Task Server()
        {
            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithDescription($"Information about {Context.Guild.Name}!")
                .WithColor(new Color(255, 0, 170))
                .AddField("Created on", Context.Guild.CreatedAt.LocalDateTime.ToString())
                .AddField("Members", (Context.Guild as SocketGuild).MemberCount, true)
                .AddField("Online members", (Context.Guild as SocketGuild).Users.Where(u => u.Status != UserStatus.Offline).Count(), true);
            

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        
    }
}
