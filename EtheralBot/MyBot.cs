using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Setup
namespace EtheralBot

{
    enum chances
    {
        heads = 0,
        tails = 1
    }
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        //RandomNumberGen
        Random rand;

        //Lists
        string[] memes;
        string[] greetings;
        string[] magicball;
        string[] help;
        string[] diceroll;
        string[] guard;
        string[] mikhayla;

        public MyBot()
        {
            rand = new Random();

            mikhayla = new string[]
            {
                "I don't have time for that",
                "Fudge off",
                "NERD",
                "Excuse me who are you?",
                "What do you think I am, a bot that does whatever you want?!",
                "Get a Life pleb!",
                "I'm busy here!",
                "Can I not be left alone in peace"
            };

            memes = new string[]
            {
                "mem/mem1.jpg",
                "mem/mem2.jpg",
                "mem/mem3.jpg",
                "mem/mem4.jpg",
                "mem/mem5.jpg",
                "mem/mem6.jpg",
                "mem/mem7.jpg",
                "mem/mem8.jpg",
                "mem/mem9.jpg",
                "mem/mem10.jpg",
                "mem/mem11.jpg",
                "mem/mem12.jpg",
                "mem/mem13.jpg",
                "mem/mem14.jpg",
                "mem/mem15.jpg",
                "mem/mem16.jpg",
                "mem/mem17.jpg",
                "mem/mem18.jpg",
                "mem/mem19.jpg",
                "mem/mem20.jpg"
            };

            greetings = new string[]
            {
                "Hi! ",
                "Sup ",
                "Yo ",
                "How's it going ",
                "What's new ",
                "Suh ",
                "Hello "
            };

            guard = new string[]
            {
                " I shall guard this server with my Life",
                " Nothing shall distract me",
                " I will show no mercy",
                " Our enemies will tremble when they see me",
                " I don't listen to you",
                " I listen to no one",
                " Bite my shiny metal butt"
            };

            diceroll = new string[]
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12"
            };

            magicball = new string[]
            {
                "It is certain",
                "It is decidedly so",
                "Without a doubt",
                "Yes, definitely",
                "You may rely on it",
                "As I see it, yes",
                "Most likely",
                "Outlook good",
                "Yes",
                "Signs point to yes",
                "Reply hazy try again",
                "Ask again later",
                "Better not tell you now",
                "Cannot predict now",
                "Concentrate and ask again",
                "Don't count on it",
                "My reply is no",
                "My sources say no",
                "Outlook not so good",
                "Very doubtful"
            };

            //Log Setup
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;
            });

            //Commands Start
            commands = discord.GetService<CommandService>();

            RegisterMemeCommand();

            //Commands
            {
                commands.CreateCommand("hello") //hello command
                    .Alias(new string[] { "hi", "sup", "yo", "suh" })
                    .Do(async (e) =>
                    {
                        int randomMikhaylaRoll = rand.Next(12);
                        int randomGreetingsRoll = rand.Next(12);
                        int randomGreetingsIndex = rand.Next(greetings.Length);
                        int randomMikhaylaIndex = rand.Next(mikhayla.Length);
                        string textToPost = greetings[randomGreetingsIndex];
                        string textToPost2 = mikhayla[randomMikhaylaIndex];
                        if (randomGreetingsRoll > randomMikhaylaRoll)
                            await e.Channel.SendMessage(textToPost + e.User.Name);
                        else
                            await e.Channel.SendMessage(textToPost2);                            
                    });

                commands.CreateCommand("8ball")
                    .Parameter("a", ParameterType.Unparsed)
                    .Do(async (e) =>
                    {
                        int random8ballIndex = rand.Next(magicball.Length);
                        string textToPost = magicball[random8ballIndex];
                        await e.Channel.SendMessage(textToPost);
                    });

                commands.CreateCommand("ping")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("pong!");
                    });

                commands.CreateCommand("ding")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("dong!");
                    });

                commands.CreateCommand("say")
                    .Parameter("say", ParameterType.Unparsed)
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage(e.GetArg("say"));
                        await e.Channel.SendIsTyping();
                        await e.Channel.SendMessage("");
                    });

                commands.CreateCommand("roll")
                    .Do(async (e) =>
                    {
                        int UserdicerollIndex = rand.Next(12);
                        int BotdicerollIndex = rand.Next(12);
                        string UserrollToPost = diceroll[UserdicerollIndex];
                        string BotrollToPost = diceroll[BotdicerollIndex];
                        await e.Channel.SendMessage("You rolled " + UserrollToPost + "\n I rolled " + BotrollToPost);
                        if (UserdicerollIndex == BotdicerollIndex)
                            await e.Channel.SendMessage("We tied");
                        else
                        if (UserdicerollIndex > BotdicerollIndex)
                            await e.Channel.SendMessage(e.User.Name + " Wins\nI Lose");
                        else
                            await e.Channel.SendMessage("I win\n" + e.User.Name + " Loses");
                    });

                commands.CreateCommand("guard")
                    .Do(async (e) =>
                    {
                        int randomMikhaylaRoll = rand.Next(12);
                        int randomGuardRoll = rand.Next(12);
                        int randomGuardIndex = rand.Next(guard.Length);
                        int randomMikhaylaIndex = rand.Next(mikhayla.Length);
                        string guardToPost = greetings[randomGuardIndex];
                        string guardToPost2 = mikhayla[randomMikhaylaIndex];
                        if (randomGuardRoll > randomMikhaylaRoll)
                            await e.Channel.SendMessage(guardToPost + e.User.Name);
                        else
                            await e.Channel.SendMessage(guardToPost2);
                    });
                commands.CreateCommand("flip")
                    .Parameter("flip", ParameterType.Unparsed)
                    .Do(async (e) =>
                    {
                        int ran = rand.Next(2);
                        //Console.WriteLine(ran);
                        string hot = e.GetArg("flip");
                        if (hot == "heads" || hot == "tails")
                            if (Convert.ToInt32(chances.heads) == ran)
                                {
                                    await e.Channel.SendMessage("Heads");
                                    if (hot == chances.heads.ToString())
                                    {
                                        await e.Channel.SendMessage("You win.");
                                    }
                                    else
                                    {
                                        await e.Channel.SendMessage("You lose.");
                                    }
                                }
                            else if (Convert.ToInt32(chances.tails) == ran)
                                {
                                    await e.Channel.SendMessage("Tails");
                                    if (hot == chances.tails.ToString())
                                {
                                        await e.Channel.SendMessage("You win.");
                                }
                                    else
                                    {
                                        await e.Channel.SendMessage("You lose.");
                                    }
                                }
                            else
                                {
                                    await e.Channel.SendMessage("An error has occurred.");
                                }
                        else
                        {
                            await e.Channel.SendMessage("You need to specify heads or tails if you want to play the game");
                        }
                    });

                commands.CreateCommand("rps")
                    .Do(async (e) =>
                    {

                    });

            }

            //Discord Connect
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("TokenGoesHere", TokenType.Bot);
            });
        }

        private void RegisterMemeCommand()
        {
            commands.CreateCommand("meme")
                .Do(async (e) =>
                {
                    int randomMemeIndex = rand.Next(memes.Length);
                    string memeToPost = memes[randomMemeIndex];
                    await e.Channel.SendFile(memeToPost);
                });
        }

        //Log Sender
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
