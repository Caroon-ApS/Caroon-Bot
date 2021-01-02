using Bot.Utilities;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Modules
{
    public class ImageFunctionality : ModuleBase<SocketCommandContext>
    {
        private readonly Images _images;

        public ImageFunctionality(Images images)
        {
            _images = images;
        }


        [Command("image", RunMode = RunMode.Async)]
        public async Task Image(SocketGuildUser user, string imageURL = null, string bannerText = null, string bannerSubText = null)
        {
            var path = await _images.CreateImage(user, imageURL, bannerText, bannerSubText);
            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
    }
}
