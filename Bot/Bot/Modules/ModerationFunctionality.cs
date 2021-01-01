using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Modules
{
    public class ModerationFunctionality : ModuleBase<SocketCommandContext>
    {
        /* Dangerous */
        [Command("purge")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Purge(int amount)
        {
                var messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
                await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);

                var message = await Context.Channel.SendMessageAsync($"{messages.Count()} messages deleted succesfully!");
                await Task.Delay(2500);
                await message.DeleteAsync();
        }
        
    }
}
