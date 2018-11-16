using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;

namespace Beep_Bot
{
    class Program
    {
        static DiscordClient client;
        static CommandsNextModule commands;
        static InteractivityModule interact;

        static async Task Main(string[] args)
        {
            client = new DiscordClient(new DiscordConfiguration()
            {
                Token = "{Your Token Here}",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug

            });

            commands = client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });

            commands.RegisterCommands<BeepCommands>();

            interact = client.UseInteractivity(new InteractivityConfiguration()
            {

            });

            //client.MessageCreated += async e =>
            //{
            //    if (e.Message.Content.StartsWith("!"))
            //    {
            //        switch (e.Message.Content)
            //        {
            //            case "!Beep":
            //                await e.Message.RespondAsync("Boop");
            //                break;
            //            case "!Boop":
            //                await e.Message.RespondAsync("Bop");
            //                break;
            //            default:
            //                await e.Message.RespondAsync("Paul Keep doing your homework!");
            //                break;
            //        }
            //    }
            //};

            await client.ConnectAsync();

            await Task.Delay(-1);
        }

        
    }
}
